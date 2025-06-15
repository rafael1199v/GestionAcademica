import React from 'react'
import { Link } from 'react-router-dom'

function SideBarItem({isSelected, text, onClick, icon, navigateTo="/"}) {
  return (
  <Link to={navigateTo} onClick={onClick}>
         <p
         className={`flex flex-row items-center gap-3 rounded-lg px-4 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 hover:text-gray-700 ${isSelected ? 'bg-gray-100 text-gray-700' : ''}`}
         >
         {icon}
         {text}
         </p>
  </Link>
  )
}

export default SideBarItem