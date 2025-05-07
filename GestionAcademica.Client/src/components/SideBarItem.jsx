import React from 'react'

function SideBarItem({isSelected, text, onClick}) {
  return (
    <li onClick={onClick}>
        <a
        href="#"
        className={`block rounded-lg px-4 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 hover:text-gray-700 ${isSelected ? 'bg-gray-100 text-gray-700' : ''}`}
        >
        {text}
        </a>
  </li>
  )
}

export default SideBarItem