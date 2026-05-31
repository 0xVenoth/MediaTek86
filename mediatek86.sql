-- =====================================================================
--  MediaTek86 - Gestion des absences du personnel
--  Script de creation et d'alimentation de la base de donnees (MySQL)
--  A executer depuis phpMyAdmin (Wampserver) ou la console MySQL,
--  connecte en tant qu'utilisateur 'root'.
-- =====================================================================

-- ---------------------------------------------------------------------
-- 1) CREATION DE LA BASE DE DONNEES
-- ---------------------------------------------------------------------
DROP DATABASE IF EXISTS mediatek86;
CREATE DATABASE mediatek86
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
USE mediatek86;

-- ---------------------------------------------------------------------
-- 2) CREATION DES TABLES (issues du Modele Conceptuel de Donnees)
-- ---------------------------------------------------------------------

-- Table service
CREATE TABLE service (
    idservice INT AUTO_INCREMENT,
    nom       VARCHAR(50) NOT NULL,
    CONSTRAINT pk_service PRIMARY KEY (idservice)
) ENGINE=InnoDB;

-- Table personnel (un personnel appartient a un service)
CREATE TABLE personnel (
    idpersonnel INT AUTO_INCREMENT,
    idservice   INT NOT NULL,
    nom         VARCHAR(50) NOT NULL,
    prenom      VARCHAR(50) NOT NULL,
    tel         VARCHAR(15),
    mail        VARCHAR(100),
    CONSTRAINT pk_personnel PRIMARY KEY (idpersonnel),
    CONSTRAINT fk_personnel_service
        FOREIGN KEY (idservice) REFERENCES service (idservice)
) ENGINE=InnoDB;

-- Table motif
CREATE TABLE motif (
    idmotif INT AUTO_INCREMENT,
    libelle VARCHAR(50) NOT NULL,
    CONSTRAINT pk_motif PRIMARY KEY (idmotif)
) ENGINE=InnoDB;

-- Table absence (une absence concerne un personnel et a un motif)
-- Cle primaire composee (idpersonnel, datedebut) : un agent ne peut pas
-- avoir deux absences commencant exactement au meme moment.
CREATE TABLE absence (
    idpersonnel INT      NOT NULL,
    datedebut   DATETIME NOT NULL,
    datefin     DATETIME NOT NULL,
    idmotif     INT      NOT NULL,
    CONSTRAINT pk_absence PRIMARY KEY (idpersonnel, datedebut),
    CONSTRAINT fk_absence_personnel
        FOREIGN KEY (idpersonnel) REFERENCES personnel (idpersonnel),
    CONSTRAINT fk_absence_motif
        FOREIGN KEY (idmotif) REFERENCES motif (idmotif)
) ENGINE=InnoDB;

-- Table responsable (ajout demande : login + pwd, pas d'identifiant,
-- une seule ligne, pour la connexion du responsable a l'application)
CREATE TABLE responsable (
    login VARCHAR(64) NOT NULL,
    pwd   VARCHAR(64) NOT NULL
) ENGINE=InnoDB;

-- ---------------------------------------------------------------------
-- 3) CREATION D'UN UTILISATEUR APPLICATIF (acces securise a la base)
--    A adapter : remplacez le mot de passe par le votre.
-- ---------------------------------------------------------------------
CREATE USER IF NOT EXISTS 'mediatek86user'@'localhost'
    IDENTIFIED BY 'MediaTek86!2026';

-- L'application a seulement besoin de lire/ecrire les donnees,
-- pas de modifier la structure : on n'accorde que SELECT/INSERT/UPDATE/DELETE.
GRANT SELECT, INSERT, UPDATE, DELETE
    ON mediatek86.*
    TO 'mediatek86user'@'localhost';

FLUSH PRIVILEGES;

-- ---------------------------------------------------------------------
-- 4) ALIMENTATION DE LA BASE
-- ---------------------------------------------------------------------

-- 4.1) Responsable : login + mot de passe chiffre en SHA2 256 bits.
--      Identifiants choisis :  login = admin  /  mot de passe = mediatek86
--      (SHA2(...,256) renvoie 64 caracteres hexadecimaux -> VARCHAR(64))
INSERT INTO responsable (login, pwd) VALUES
    ('admin', SHA2('mediatek86', 256));

-- 4.2) Motifs (contenu fixe, non modifie dans l'application)
INSERT INTO motif (libelle) VALUES
    ('vacances'),
    ('maladie'),
    ('motif familial'),
    ('conge parental');

-- 4.3) Services (contenu fixe, non modifie dans l'application)
INSERT INTO service (nom) VALUES
    ('administratif'),
    ('mediation culturelle'),
    ('pret');

-- 4.4) Personnel : une dizaine d'exemples (idpersonnel auto -> 1 a 10)
INSERT INTO personnel (idservice, nom, prenom, tel, mail) VALUES
    (1, 'Martin',  'Sophie', '0612345601', 'sophie.martin@mediatek86.fr'),
    (1, 'Bernard', 'Lucas',  '0612345602', 'lucas.bernard@mediatek86.fr'),
    (2, 'Dubois',  'Emma',   '0612345603', 'emma.dubois@mediatek86.fr'),
    (2, 'Thomas',  'Hugo',   '0612345604', 'hugo.thomas@mediatek86.fr'),
    (3, 'Robert',  'Lea',    '0612345605', 'lea.robert@mediatek86.fr'),
    (3, 'Richard', 'Nathan', '0612345606', 'nathan.richard@mediatek86.fr'),
    (1, 'Petit',   'Chloe',  '0612345607', 'chloe.petit@mediatek86.fr'),
    (2, 'Durand',  'Theo',   '0612345608', 'theo.durand@mediatek86.fr'),
    (3, 'Leroy',   'Manon',  '0612345609', 'manon.leroy@mediatek86.fr'),
    (1, 'Moreau',  'Enzo',   '0612345610', 'enzo.moreau@mediatek86.fr');

-- 4.5) Absences : une cinquantaine d'exemples (5 par agent)
--      idmotif : 1=vacances 2=maladie 3=motif familial 4=conge parental
INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES
    (1,  '2023-02-06 08:00:00', '2023-02-17 18:00:00', 1),
    (1,  '2023-06-12 08:00:00', '2023-06-13 18:00:00', 2),
    (1,  '2023-11-20 08:00:00', '2023-11-24 18:00:00', 3),
    (1,  '2024-03-04 08:00:00', '2024-03-15 18:00:00', 1),
    (1,  '2024-09-09 08:00:00', '2024-09-10 18:00:00', 2),
    (2,  '2023-01-16 08:00:00', '2023-01-20 18:00:00', 2),
    (2,  '2023-05-22 08:00:00', '2023-06-02 18:00:00', 1),
    (2,  '2023-10-09 08:00:00', '2023-10-11 18:00:00', 3),
    (2,  '2024-02-12 08:00:00', '2024-02-23 18:00:00', 1),
    (2,  '2024-08-05 08:00:00', '2024-08-30 18:00:00', 4),
    (3,  '2023-03-13 08:00:00', '2023-03-14 18:00:00', 2),
    (3,  '2023-07-03 08:00:00', '2023-07-21 18:00:00', 1),
    (3,  '2023-12-18 08:00:00', '2023-12-29 18:00:00', 1),
    (3,  '2024-04-08 08:00:00', '2024-04-09 18:00:00', 3),
    (3,  '2024-10-14 08:00:00', '2024-10-18 18:00:00', 2),
    (4,  '2023-02-20 08:00:00', '2023-03-03 18:00:00', 1),
    (4,  '2023-06-26 08:00:00', '2023-06-27 18:00:00', 2),
    (4,  '2023-11-06 08:00:00', '2023-11-10 18:00:00', 3),
    (4,  '2024-01-29 08:00:00', '2024-02-09 18:00:00', 1),
    (4,  '2024-07-15 08:00:00', '2024-08-12 18:00:00', 4),
    (5,  '2023-04-10 08:00:00', '2023-04-14 18:00:00', 2),
    (5,  '2023-08-07 08:00:00', '2023-08-25 18:00:00', 1),
    (5,  '2023-12-04 08:00:00', '2023-12-05 18:00:00', 2),
    (5,  '2024-05-13 08:00:00', '2024-05-24 18:00:00', 1),
    (5,  '2024-11-18 08:00:00', '2024-11-22 18:00:00', 3),
    (6,  '2023-01-09 08:00:00', '2023-01-13 18:00:00', 3),
    (6,  '2023-05-15 08:00:00', '2023-05-26 18:00:00', 1),
    (6,  '2023-09-25 08:00:00', '2023-09-26 18:00:00', 2),
    (6,  '2024-03-18 08:00:00', '2024-03-29 18:00:00', 1),
    (6,  '2024-10-07 08:00:00', '2024-10-09 18:00:00', 2),
    (7,  '2023-03-06 08:00:00', '2023-03-08 18:00:00', 2),
    (7,  '2023-07-17 08:00:00', '2023-08-04 18:00:00', 1),
    (7,  '2023-11-27 08:00:00', '2023-11-28 18:00:00', 2),
    (7,  '2024-02-05 08:00:00', '2024-02-16 18:00:00', 1),
    (7,  '2024-06-24 08:00:00', '2024-06-28 18:00:00', 3),
    (8,  '2023-04-24 08:00:00', '2023-05-05 18:00:00', 1),
    (8,  '2023-08-21 08:00:00', '2023-08-22 18:00:00', 2),
    (8,  '2023-12-11 08:00:00', '2023-12-15 18:00:00', 3),
    (8,  '2024-04-15 08:00:00', '2024-04-26 18:00:00', 1),
    (8,  '2024-09-23 08:00:00', '2024-12-23 18:00:00', 4),
    (9,  '2023-02-13 08:00:00', '2023-02-14 18:00:00', 2),
    (9,  '2023-06-05 08:00:00', '2023-06-23 18:00:00', 1),
    (9,  '2023-10-16 08:00:00', '2023-10-20 18:00:00', 3),
    (9,  '2024-01-22 08:00:00', '2024-02-02 18:00:00', 1),
    (9,  '2024-08-19 08:00:00', '2024-08-21 18:00:00', 2),
    (10, '2023-03-20 08:00:00', '2023-03-31 18:00:00', 1),
    (10, '2023-07-10 08:00:00', '2023-07-12 18:00:00', 2),
    (10, '2023-11-13 08:00:00', '2023-11-17 18:00:00', 3),
    (10, '2024-05-06 08:00:00', '2024-05-17 18:00:00', 1),
    (10, '2024-10-21 08:00:00', '2024-10-22 18:00:00', 2);

-- ---------------------------------------------------------------------
-- 5) VERIFICATIONS (facultatif)
-- ---------------------------------------------------------------------
-- SELECT COUNT(*) AS nb_personnel FROM personnel;   -- attendu : 10
-- SELECT COUNT(*) AS nb_absence   FROM absence;      -- attendu : 50
-- SELECT * FROM responsable;
-- =====================================================================
--  Fin du script
-- =====================================================================
