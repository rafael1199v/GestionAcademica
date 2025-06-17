import React from 'react'

function ApplicationCard({ item, role, onClick }) {

  return (
    <a href="#" className="block max-w-sm p-6 bg-white border border-gray-200 rounded-lg shadow-sm hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
      onClick={onClick}
    >
        <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{ item.vacancyName }</h5>
        {role == 1 || role == 5 ? (<>
          <p className="mb-2 font-normal text-gray-700 dark:text-gray-400">{ "Postulante: " + item.applicantName + (role==5 ? ("\nPuesto ofrecido por: " + item.ownerName):"") }</p>
          <p className="text-sm text-gray-700 dark:text-gray-400">Archivos enviados: { item.fileQtty }</p>
        </>) : (<>
          <p className="mb-2 font-normal text-gray-700 dark:text-gray-400">{item.vacancyDesc}</p>
          <p className="text-sm text-gray-700 dark:text-gray-400">Estado: {item.status}</p>
        </>)}
    </a>
  )
}

export default ApplicationCard