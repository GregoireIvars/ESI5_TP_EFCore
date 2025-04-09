
import { Link, Outlet } from 'react-router-dom'

const Layout = () => {
  return (
    <>
      <header className="bg-blue-600 text-white p-4 shadow-md">
        <nav className="flex justify-between items-center">
          <h1 className="text-xl font-bold">Gestion d'Événements</h1>
          <ul className="flex gap-4">
            <li>
              <Link to="/" className="hover:underline">Accueil</Link>
            </li>
            <li>
              <Link to="/dashboard" className="hover:underline">Dashboard</Link>
            </li>
          </ul>
        </nav>
      </header>

      <main className="p-6">
        <Outlet />
      </main>
    </>
  )
}

export default Layout
