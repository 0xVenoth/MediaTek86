# MediaTek86 - Application de gestion du personnel

Application de bureau (C# / WinForms, .NET Framework 4.7.2) permettant au responsable
du personnel de la médiathèque MediaTek86 de gérer les membres du personnel et leurs absences.

## Architecture (MVC)

Le projet est structuré selon le modèle **MVC**, dans les packages suivants :

| Package | Rôle |
|---|---|
| `vue` | Interfaces graphiques (fenêtres WinForms) |
| `controleur` | Liaison entre les vues et l'accès aux données |
| `modele` | Classes métier (Personnel, Service, Motif, Absence, Responsable) |
| `dal` | Couche d'accès aux données : chaîne de connexion et requêtes SQL |
| `bddmanager` | Gestionnaire technique de la connexion MySQL (singleton) |

Le sens des appels est : **vue → controleur → dal (AccesDonnees) → bddmanager**.

## Connexion à la base de données

L'application se connecte à la base `mediatek86` (MySQL/Wampserver) avec l'utilisateur
applicatif `mediatek86user`, qui ne possède que les droits SELECT, INSERT, UPDATE et DELETE.
La chaîne de connexion se trouve dans `dal/AccesDonnees.cs`.

Le mot de passe du responsable est stocké chiffré (SHA2 256 bits) dans la table `responsable` ;
la vérification de la connexion est faite directement par MySQL avec la fonction `SHA2`.

## Interfaces (partie Vue)

- **FrmConnexion** : connexion du responsable (login / mot de passe).
- **FrmGestionPersonnel** : liste des personnels, ajout / modification / suppression,
  accès à la gestion des absences.
- **FrmGestionAbsence** : liste et gestion des absences du personnel sélectionné.

## Cas d'utilisation couverts

1. Se connecter
2. Ajouter un personnel
3. Supprimer un personnel
4. Modifier un personnel
5. Afficher les absences
6. Ajouter une absence
7. Supprimer une absence
8. Modifier une absence

## État d'avancement

- [x] Structure MVC + projet WinForms
- [x] Codage du visuel des interfaces (partie Vue)
- [x] Couche d'accès aux données (dal + bddmanager)
- [x] Contrôleur
- [x] Fonctionnalités des 8 cas d'utilisation (codées et testées)
