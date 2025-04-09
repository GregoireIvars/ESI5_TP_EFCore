import React from 'react'

const features = [
  {
    title: '🎉 Gestion des événements',
    description: "Créer, modifier, supprimer et consulter les événements. Filtrer par date, lieu, catégorie ou statut, avec pagination."
  },
  {
    title: '🗂️ Catégories d’événements',
    description: "Organisation logique des événements par type, avec CRUD complet sur les catégories disponibles."
  },
  {
    title: '🧑‍🤝‍🧑 Participants',
    description: "Inscription/désinscription des participants à des événements, gestion de leur profil, et historique de participation."
  },
  {
    title: '🗓️ Sessions et programme',
    description: "Ajout/suppression de sessions à un événement, consultation du programme, gestion des créneaux et intervenants."
  },
  {
    title: '📍 Lieux et salles',
    description: "CRUD sur les lieux d'événements et gestion des salles internes, avec attribution des sessions aux salles."
  },
  {
    title: '⭐ Notation & retours',
    description: "Système de notation des sessions par les participants, avec commentaires et scores."
  },
  {
    title: '📊 Statistiques',
    description: "Analyse et génération de rapports basés sur les notes et la fréquentation des événements."
  },
  {
    title: '💸 Transactions & recommandations',
    description: "Fonctionnalités avancées de gestion financière et suggestion intelligente de sessions."
  }
]

const Home = () => {
  return (
    <div className="max-w-5xl mx-auto py-12 px-4 sm:px-6 lg:px-8">
      <h1 className="text-4xl font-bold text-teal-700 mb-4 text-center">Bienvenue sur mon projet API Events 🌸</h1>
      <p className="text-center text-gray-600 mb-12">
        Ce projet a été développé avec Entity Framework Core & .NET pour la partie API, et React + TypeScript pour le front.
        Voici un aperçu des fonctionnalités proposées :
      </p>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
        {features.map((feature, index) => (
          <div key={index} className="bg-rose-50 border border-rose-200 rounded-lg p-6 shadow hover:shadow-md transition">
            <h2 className="text-xl font-semibold text-rose-700 mb-2">{feature.title}</h2>
            <p className="text-gray-700">{feature.description}</p>
          </div>
        ))}
      </div>
    </div>
  )
}

export default Home
