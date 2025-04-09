import React, { useState, useEffect } from 'react';
import { fetchEvents } from '../../services/api';
import { Event } from '../../types/types';
import EventCard from '../../commun/EventCard';
import { useNavigate } from 'react-router-dom';

const Dashboard: React.FC = () => {
  const [events, setEvents] = useState<Event[]>([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const navigate = useNavigate();

  useEffect(() => {
    const loadEvents = async () => {
      try {
        const res = await fetchEvents(); // 👈 assure-toi que fetchEvents accepte une page
        setEvents(res.data.items);
        setTotalPages(res.data.totalPages);
      } catch (err) {
        console.error("Erreur lors du chargement des événements", err);
      }
    };
    loadEvents();
  }, [page]);

  const handleEventClick = (id: number) => {
    navigate(`/event/${id}`);
  };

  return (
    <div className="p-6">
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-3xl font-bold">Événements à venir</h2>
        <button
          onClick={() => navigate('/event/new')}
          className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
        >
          + Créer un événement
        </button>
      </div>

      {events.length === 0 ? (
        <p className="text-center text-gray-500">Aucun événement trouvé.</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {events.map((event) => (
            <div
              key={event.id}
              onClick={() => handleEventClick(event.id)}
              className="cursor-pointer"
            >
              <EventCard event={event} />
            </div>
          ))}
        </div>
      )}

      {totalPages > 1 && (
        <div className="flex justify-center mt-6 items-center gap-4">
          <button
            onClick={() => setPage((prev) => Math.max(prev - 1, 1))}
            className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
          >
            Précédent
          </button>
          <span>
            Page {page} sur {totalPages}
          </span>
          <button
            onClick={() => setPage((prev) => Math.min(prev + 1, totalPages))}
            className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
          >
            Suivant
          </button>
        </div>
      )}
    </div>
  );
};

export default Dashboard;
