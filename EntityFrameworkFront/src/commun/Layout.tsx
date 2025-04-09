import React from 'react'
import { Link, Outlet } from 'react-router-dom'

const Layout = () => {
  return (
    <>
      <header className="bg-gradient-to-r from-rose-100 via-teal-100 to-green-100 p-4 shadow-md border-b border-teal-200">
        <nav className="flex justify-between items-center max-w-6xl mx-auto">
          <h1 className="text-2xl font-bold text-teal-700">Event Planner</h1>
          <ul className="flex gap-6 text-teal-800 font-medium">
            <li>
              <Link to="/" className="hover:text-rose-500 transition duration-200">Accueil</Link>
            </li>
            <li>
              <Link to="/dashboard" className="hover:text-emerald-600 transition duration-200">Dashboard</Link>
            </li>
          </ul>
        </nav>
      </header>

      <main className="p-6 bg-white min-h-screen">
        <Outlet />
      </main>
    </>
  )
}

export default Layout
