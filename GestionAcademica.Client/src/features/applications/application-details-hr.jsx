import { use } from "react"
import { useApplicationDetailsHr } from "../../hooks/useApplicationDetailsHr"

function ApplicationDetailsHr() {
  const { application } = useApplicationDetailsHr();

  return (
    <div className="max-w-3xl mx-auto mt-10 bg-white shadow-xl rounded-2xl p-6 space-y-6">
      <h1 className="text-2xl font-bold text-gray-800">Detalles de Solicitud</h1>

      <div className="grid grid-cols-2 gap-4 text-gray-700">
        <div><strong>Solicitante:</strong> {application?.applicantName}</div>
        <div><strong>Materia:</strong> {application?.subjectName}</div>
        <div><strong>Carrera:</strong> {application?.careerName}</div>
        <div><strong>Administrador:</strong> {application?.administratorName}</div>
      </div>

      <div>
        <h2 className="text-lg font-semibold mt-6 mb-2">Archivos</h2>
        <ul className="space-y-2">
          {application?.files.map(file => (
            <li
              key={file.id}
              className="flex justify-between items-center bg-gray-100 px-4 py-2 rounded-lg"
            >
              <span>{file.name}{file.extension}</span>
              <button className="text-blue-600 hover:underline text-sm cursor-pointer">
                Ver archivo
              </button>
            </li>
          ))}
        </ul>
      </div>

          <div className="flex justify-end space-x-4 mt-6">
        <button
          className="flex items-center gap-2 bg-green-500 text-white px-4 py-2 rounded-xl hover:bg-green-600 active:scale-95 shadow-md transition cursor-pointer"
        >
          Aceptar
        </button>
        <button
          className="flex items-center gap-2 bg-red-500 text-white px-4 py-2 rounded-xl hover:bg-red-600 active:scale-95 shadow-md transition cursor-pointer"
        >
          Rechazar
        </button>
      </div>
    </div>
  )
}

export default ApplicationDetailsHr