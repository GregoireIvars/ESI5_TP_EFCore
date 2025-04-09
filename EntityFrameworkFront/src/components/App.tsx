import { Routes, Route } from 'react-router-dom'
import Layout from '../commun/Layout'
import Home from './pages/home'
import Dashboard from './pages/dashboard'


function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="dashboard" element={<Dashboard />} />
      </Route>
    </Routes>
  )
}

export default App
