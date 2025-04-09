import React from 'react';
import { Participant } from '../types/types';

type Props = {
  participants: Participant[];
};

const ParticipantList: React.FC<Props> = ({ participants }) => {
  return (
    <div className="bg-white p-4 rounded-lg shadow">
      <h3 className="text-lg font-semibold mb-2">Participants</h3>
      <ul className="space-y-2">
        {participants.map((p) => (
          <li key={p.id} className="border-b pb-1">
            {p.firstName} {p.lastName} — {p.email}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ParticipantList;
