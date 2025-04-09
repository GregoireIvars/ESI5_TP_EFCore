import { Routes, Route } from 'react-router-dom';
import Layout from '../commun/Layout';
import Home from './pages/home';
import Dashboard from './pages/dashboard';
import EventDetails from './pages/EventDetails';
import EventForm from '../commun/EventForm';


function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="dashboard" element={<Dashboard />} />
        <Route path="/event/new" element={<EventForm />} />
        <Route path="/event/:id" element={<EventDetails />} />
      </Route>
    </Routes>
  );
}

export default App;
