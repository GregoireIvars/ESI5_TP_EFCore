export type Event = {
    id: number;
    title: string;
    description: string
    startDate: string;
    endDate: string;
    status: 'Upcoming' | 'Ongoing' | 'Completed';
    location?: Location;
    category?: Category;
  };
  
  export interface EventInput {
    id: number;
    title: string;
    description: string; // Added description property
    startDate: string;
    endDate: string;
    category: string;
    location: string;
    status: string;
  }
  
  export type Location = {
    id: number;
    name: string;
    address: string;
    city: string;
    country: string;
  };
  
  export type Category = {
    id: number;
    name: string;
  };
  
  export type Participant = {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    company?: string;
    jobTitle?: string;
  };
  