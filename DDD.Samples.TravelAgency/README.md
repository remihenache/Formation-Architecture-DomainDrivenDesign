### Exercice 1: Modélisation du Domaine de Réservation de Vols

#### Contexte du Domaine
Le domaine des réservations de vols gère la recherche, la sélection, et la réservation de vols par les voyageurs. Ce domaine inclut des règles métier telles que la gestion des places disponibles, la catégorisation des sièges (économie, affaires, première classe), et la fluctuation des prix en fonction de la demande.

#### Éléments à Modéliser

1. **Agrégat : Réservation de Vol**
    - **Racine d'Agrégat :** `ReservationVol`
    - **Entités :** `Vol`, `Passager`
    - **Objets de Valeur :** `Itineraire`, `IdentitePassager`, `Siege`, `TarifVol`
    - **Invariants :**
        - Un vol ne peut être réservé que si des sièges sont disponibles.
        - Le tarif peut varier en fonction de la classe de réservation et de la période d'achat.

2. **Repository :** `ReservationVolRepository`
    - Gère la persistance des agrégats de réservation de vol.

3. **Factory :** `ReservationVolFactory`
    - Valide et crée des instances de `ReservationVol` en vérifiant la disponibilité et le tarif.

#### Règles Métier et Invariants à Implémenter

- **Validation de Disponibilité :** Avant de finaliser une réservation, vérifier que le vol choisi a des sièges disponibles dans la classe souhaitée.
- **Calcul du Tarif :** Le tarif est déterminé en fonction de la classe de siège, avec des fluctuations possibles basées sur la demande et la proximité de la date de vol.

### Domain Event

- **Événement :** `ReservationVolConfirmee`
    - **Quand :** Cet événement est émis lorsque la réservation d'un vol est confirmée.
    - **Données :** Identifiant de la réservation, détails du vol, identité du passager, tarif final.


### Exercice 2: Modélisation du Domaine de Location de Voitures

#### Contexte du Domaine
À la suite de la confirmation d'une réservation de vol, les voyageurs ont souvent besoin de louer une voiture à leur destination. Ce domaine gère la sélection et la réservation de véhicules.

#### Éléments à Modéliser

1. **Agrégat : Réservation de Voiture**
    - **Racine d'Agrégat :** `ReservationVoiture`
    - **Entités :** `Voiture`
    - **Objets de Valeur :** `PeriodeLocation`, `DetailsVoiture`, `TarifLocation`
    - **Invariants :**
        - Une voiture ne peut être louée que si elle est disponible pour la période demandée.
        - Des options supplémentaires (GPS, siège bébé, assurance) peuvent modifier le tarif de base.

2. **Repository :** `ReservationVoitureRepository`
    - Gère la persistance des agrégats de réservation de voiture.

3. **Factory :** `ReservationVoitureFactory`
    - Crée des instances de `ReservationVoiture` basées sur les préférences du client et la disponibilité des véhicules.

#### Réaction à l'Événement Domaine

- **Réaction à `ReservationVolConfirmee` :**
    - Utiliser cet événement pour proposer automatiquement des options de location de voiture correspondant aux dates et à la destination du vol réservé.

#### Règles Métier et Invariants à Implémenter

- **Sélection Basée sur l'Événement :** Les options de véhicules proposées doivent correspondre à la destination et aux dates du vol réservé.
- **Gestion des Options :** Permettre aux utilisateurs de personnaliser leur location avec des options supplémentaires et calculer le tarif en conséquence.

