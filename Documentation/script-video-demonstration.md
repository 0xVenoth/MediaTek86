# Script de la vidéo de démonstration — MediaTek86

Durée visée : **5 minutes**. Texte à dire à l'oral en colonne droite, actions à
l'écran en colonne gauche. Parler posément, montrer chaque action avant de
cliquer.

---

## 0. Avant de lancer l'enregistrement (préparation)

- Démarrer Wampserver (icône verte) pour que MySQL soit actif.
- Vérifier que la base `mediatek86` est bien présente.
- Avoir l'application installée et prête à être lancée.
- Fermer les fenêtres inutiles, mettre le bureau au propre.

---

## 1. Introduction (≈ 30 s)

**À l'écran :** bureau, puis on lance l'application (raccourci MediaTek86).

> « Bonjour. Je vais vous présenter MediaTek86, une application de bureau que
> j'ai développée en C# avec Windows Forms, connectée à une base de données
> MySQL. Elle permet au responsable de la médiathèque MediaTek86 de gérer son
> personnel ainsi que les absences de chaque membre du personnel.
> L'application est construite selon une architecture MVC : modèle, vue,
> contrôleur, avec une couche d'accès aux données. Voyons maintenant ses
> fonctionnalités. »

---

## 2. Connexion du responsable (≈ 40 s)

**À l'écran :** la fenêtre de connexion s'affiche.

> « Au lancement, l'application demande une authentification. L'accès est
> réservé au responsable du personnel : il doit saisir un login et un mot de
> passe. Le mot de passe est stocké chiffré dans la base, en SHA2 sur
> 256 bits ; il n'est jamais enregistré en clair. »

**Action 1 — erreur volontaire :** saisir un mauvais mot de passe, cliquer
« Se connecter ».

> « Si je me trompe, l'application refuse la connexion et affiche un message
> d'erreur. »

**Action 2 — connexion correcte :** login `admin`, mot de passe `mediatek86`,
cliquer « Se connecter ».

> « Avec les bons identifiants, j'accède à la fenêtre de gestion du personnel. »

---

## 3. Gestion du personnel (≈ 1 min 40)

**À l'écran :** la liste des personnels (DataGridView) avec nom, prénom,
téléphone, mail et service.

> « Voici la liste de tout le personnel de la médiathèque. Pour chaque agent,
> on voit son nom, son prénom, son téléphone, son mail et le service auquel il
> appartient : administratif, médiation culturelle ou prêt. »

### 3.1 Ajout

**Action :** cliquer « Ajouter », remplir nom, prénom, téléphone, mail,
choisir un service, cliquer « Enregistrer ».

> « Je peux ajouter un nouveau membre du personnel. Je clique sur Ajouter, la
> zone de saisie s'active. Je renseigne le nom, le prénom, le téléphone, le
> mail, et je choisis le service dans la liste déroulante. Le nom et le prénom
> sont obligatoires : si je les laisse vides, l'application m'en avertit.
> Je valide avec Enregistrer, et le nouvel agent apparaît dans la liste. »

### 3.2 Modification

**Action :** sélectionner l'agent ajouté, cliquer « Modifier », changer un
champ (ex. le téléphone), « Enregistrer ».

> « Je peux aussi modifier un agent. Je le sélectionne, je clique sur
> Modifier : ses informations se recopient dans la zone de saisie. Je change
> par exemple son numéro de téléphone, puis j'enregistre. La liste est mise à
> jour aussitôt. »

### 3.3 Suppression

**Action :** sélectionner l'agent, cliquer « Supprimer », confirmer « Oui ».

> « Enfin, je peux supprimer un agent. Une demande de confirmation s'affiche
> pour éviter toute suppression accidentelle. Je confirme, et l'agent est
> retiré de la liste. »

---

## 4. Gestion des absences (≈ 1 min 40)

**Action :** sélectionner un agent (ex. Sophie Martin), cliquer
« Gérer les absences ».

> « Pour gérer les absences d'un agent, je le sélectionne et je clique sur
> Gérer les absences. Une nouvelle fenêtre s'ouvre, avec le nom de l'agent en
> titre et la liste de ses absences : date de début, date de fin et motif.
> Les motifs possibles sont : vacances, maladie, motif familial et congé
> parental. »

### 4.1 Ajout

**Action :** « Ajouter », choisir une date de début, une date de fin, un
motif, « Enregistrer ».

> « J'ajoute une absence : je choisis la date de début, la date de fin avec
> les calendriers, et le motif dans la liste. J'enregistre, et l'absence
> apparaît dans la liste. »

### 4.2 Contrôles de cohérence (point fort à montrer)

**Action 1 :** tenter une absence dont la date de fin est avant la date de
début.

> « L'application contrôle la cohérence de la saisie. Si la date de fin est
> antérieure à la date de début, elle refuse l'enregistrement. »

**Action 2 :** tenter une absence qui chevauche une absence existante (mêmes
dates qu'une absence déjà présente).

> « Elle vérifie aussi qu'une absence n'en chevauche pas une autre déjà
> enregistrée pour le même agent : impossible donc d'avoir deux absences sur
> la même période. »

### 4.3 Modification et suppression

**Action :** modifier une absence (changer le motif), enregistrer ; puis en
supprimer une avec confirmation.

> « Comme pour le personnel, je peux modifier une absence — par exemple
> changer son motif — et la supprimer après confirmation. »

**Action :** cliquer « Fermer » pour revenir à la liste du personnel.

> « Je ferme la fenêtre des absences et je reviens à la gestion du
> personnel. »

---

## 5. Conclusion (≈ 30 s)

**À l'écran :** revenir sur la fenêtre principale, puis fermer l'application.

> « Pour résumer, MediaTek86 permet au responsable de se connecter de façon
> sécurisée, de gérer entièrement le personnel et de suivre les absences, avec
> des contrôles de saisie qui garantissent la cohérence des données.
> L'application respecte l'architecture MVC, les requêtes SQL sont paramétrées
> pour la sécurité, et la connexion à la base se fait via un utilisateur aux
> droits limités. Merci de votre attention. »

---

## Repères de minutage

| Partie | Durée | Cumul |
|---|---|---|
| 1. Introduction | 30 s | 0:30 |
| 2. Connexion | 40 s | 1:10 |
| 3. Gestion du personnel | 1:40 | 2:50 |
| 4. Gestion des absences | 1:40 | 4:30 |
| 5. Conclusion | 30 s | 5:00 |

## Conseils

- Faire un essai à blanc avant d'enregistrer pour valider le timing.
- Préparer les données de test (un agent fictif à ajouter/modifier/supprimer,
  une absence qui chevauche) pour ne pas hésiter pendant l'enregistrement.
- Logiciel de capture : OBS Studio ou l'enregistreur d'écran Windows
  (Win + G), avec le micro activé.
- Parler lentement et clairement ; ne pas lire de façon monotone.
