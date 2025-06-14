import React from 'react'

function ApplicationCard({ title, content, state, onClick }) {
  return (
    <a href="#" className="block max-w-sm p-6 bg-white border border-gray-200 rounded-lg shadow-sm hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
      onClick={onClick}
    >
        <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{ title }</h5>
        <p className="mb-2 font-normal text-gray-700 dark:text-gray-400">{ content }</p>
        <p className="text-sm text-gray-700 dark:text-gray-400">Estado: { state }</p>
    </a>

  )
}

export default ApplicationCard