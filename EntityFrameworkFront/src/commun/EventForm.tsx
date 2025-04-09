import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createEvent } from "../services/api";

export default function EventForm() {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        id: 0,
        name: "",
        title: "",
        description: "",
        startDate: "",
        endDate: "",
        locationId: 0,
        categoryId: 0,
        category: "",
        location: "",
        status: "",
    });

    const handleChange = async (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        await createEvent({
            ...formData,
            title: formData.name, // Map name to title
            category: "Default Category", // Provide default category
            location: "Default Location", // Provide default location
            status: "Pending", // Provide default status
        });
    }

        const handleSubmit = async (e: React.FormEvent) => {
            e.preventDefault();
            try {
                await createEvent(formData);
                navigate("/dashboard");
            } catch (error) {
                console.error("Erreur lors de la création de l'événement", error);
            }
        };

        return (
            <form onSubmit={handleSubmit} className="p-4 max-w-xl mx-auto space-y-4">
                <input name="name" value={formData.name} onChange={handleChange} placeholder="Nom de l'événement" className="w-full p-2 border rounded" />
                <textarea name="description" value={formData.description} onChange={handleChange} placeholder="Description" className="w-full p-2 border rounded" />
                <input type="date" name="startDate" value={formData.startDate} onChange={handleChange} className="w-full p-2 border rounded" />
                <input type="date" name="endDate" value={formData.endDate} onChange={handleChange} className="w-full p-2 border rounded" />
                <input type="number" name="locationId" value={formData.locationId} onChange={handleChange} placeholder="ID du lieu" className="w-full p-2 border rounded" />
                <input type="number" name="categoryId" value={formData.categoryId} onChange={handleChange} placeholder="ID de la catégorie" className="w-full p-2 border rounded" />
                <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded">Créer</button>
            </form>
        );
    }