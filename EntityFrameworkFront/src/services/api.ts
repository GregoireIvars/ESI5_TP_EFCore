import axios from 'axios';
import { EventInput } from '../types/types';

const api = axios.create({
  baseURL: 'http://localhost:5152/api', // à adapter selon ton back
  headers: {
    'Content-Type': 'application/json',
  },
});

// Events
export const fetchEvents = () => api.get('/events');
export const fetchEventById = (id: number) => api.get(`/events/${id}`);
export const createEvent = (event: EventInput) => api.post('/events', event);
export const updateEvent = (id: number, event: EventInput) => api.put(`/events/${id}`, event);
export const deleteEvent = (id: number) => api.delete(`/events/${id}`);

// Participants
export const fetchParticipantsByEvent = (eventId: number) =>
  api.get(`/events/${eventId}/participants`);
export const registerParticipant = (eventId: number, participantId: number) =>
  api.post(`/events/${eventId}/register/${participantId}`);
export const unregisterParticipant = (eventId: number, participantId: number) =>
  api.post(`/events/${eventId}/unregister/${participantId}`);

export default api;
