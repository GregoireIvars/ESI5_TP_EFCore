    import { useEffect, useState } from "react";
    import { useParams } from "react-router-dom";
    import { fetchEventById } from "../../services/api"; // ✅ nom corrigé ici
    import type { Event } from "../../types/types";

    export default function EventDetails() {
    const { id } = useParams();
    const [event, setEvent] = useState<Event | null>(null);

    useEffect(() => {
        if (id) {
        fetchEventById(parseInt(id)) // ✅ nom corrigé ici aussi
            .then((res) => setEvent(res.data))
            .catch((err) => console.error("Erreur lors du chargement de l'événement", err));
        }
    }, [id]);

    if (!event) return <p className="text-center mt-10">Chargement...</p>;

    return (
        <div className="p-6 max-w-3xl mx-auto space-y-4">
        <h1 className="text-2xl font-bold">{event.title}</h1>
        <p>{event.description}</p>
        <p><strong>Dates :</strong> {event.startDate} → {event.endDate}</p>
        <p><strong>Lieu :</strong> {event.location?.name || "Non défini"}</p>
        <p><strong>Catégorie :</strong> {event.category?.name || "Non défini"}</p>
        </div>
    );
    }
