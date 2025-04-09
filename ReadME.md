#  EventHub — Gestion d'Événements

EventHub est une application complète de gestion d'événements comprenant une API RESTful développée en .NET (C# avec Entity Framework Core) et un front-end moderne en React + TypeScript + TailwindCSS.  
Elle permet la gestion des événements, participants, sessions, lieux, inscriptions, et bien plus.

---

## 🔧 Technologies utilisées

### Backend (.NET 8 + EF Core)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (ou autre base relationnelle)
- AutoMapper
- Swagger pour la documentation API

### Frontend (React + TypeScript)
- React 18 + Vite
- TypeScript
- Tailwind CSS
- React Router DOM
- Axios pour les appels API

---

##  Fonctionnalités

###  Gestion des événements
- CRUD complet sur les événements
- Filtrage par date, lieu, catégorie, statut
- Pagination

###  Gestion des participants
- Inscription / désinscription
- Liste des participants d’un événement
- Historique personnel d’un participant
- Gestion des données personnelles

###  Sessions & programme
- Ajout / suppression de sessions
- Attribution à des salles et créneaux
- Association d’intervenants

###  Lieux & salles
- CRUD sur les lieux
- Gestion des salles par lieu

###  Fonctions avancées
- Notation des sessions
- Statistiques (à venir)
- Gestion financière (à venir)
- Système de recommandations (à venir)

---

##  Démarrage rapide

###  Backend (.NET)

```bash
cd backend/
dotnet restore
dotnet ef database update
dotnet run
Swagger : http://localhost:5152/swagger

 Frontend (React)
bash
Copier
Modifier
cd frontend/
npm install
npm run dev
Application : http://localhost:5173

 Structure des dossiers
Backend
Dossier	Rôle
Controllers	Logique des routes API
Models	Entités de la base de données
DTOs	Objets de transfert entre front & back
Data	DbContext et seed de la base
Frontend
Dossier	Rôle
pages/	Pages principales (Dashboard, Détails...)
commun/	Composants réutilisables
services/	Fonctions d’appel API via Axios
types/	Types TypeScript
```


