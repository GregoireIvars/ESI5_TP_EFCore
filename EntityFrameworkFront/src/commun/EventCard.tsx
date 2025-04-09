import React from 'react';
import { Event } from '../types/types';
import { Link } from 'react-router-dom';

type Props = {
  event: Event;
};

const EventCard: React.FC<Props> = ({ event }) => {
  return (
    <div className="bg-white p-4 rounded-lg shadow hover:shadow-md transition">
      <h3 className="text-xl font-semibold mb-2">{event.title}</h3>
      <p className="text-sm text-gray-600">
        {new Date(event.startDate).toLocaleDateString()} - {new Date(event.endDate).toLocaleDateString()}
      </p>
      <p className="text-sm text-gray-600">Status: {event.status}</p>
      <p className="text-sm text-gray-600">Lieu: {event.location?.name}</p>
      <p className="text-sm text-gray-600">Catégorie: {event.category?.name}</p>
      <Link to={`/events/${event.id}`} className="inline-block mt-3 text-sky-600 hover:underline">
        Voir les détails
      </Link>
    </div>
  );
};

export default EventCard;
