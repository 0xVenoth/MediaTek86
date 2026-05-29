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
| `bddmanager` | Gestionnaire d'accès à la base de données MySQL |

## Interfaces (partie Vue)

- **FrmConnexion** : connexion du responsable (login / mot de passe).
- **FrmGestionPersonnel** : liste des personnels, ajout / modification / suppression,
  accès à la gestion des absences.
- **FrmGestionAbsence** : liste et gestion des absences d'un personnel sélectionné.

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
- [ ] Couche d'accès aux données (bddmanager)
- [ ] Contrôleurs et fonctionnalités (missions suivantes)
