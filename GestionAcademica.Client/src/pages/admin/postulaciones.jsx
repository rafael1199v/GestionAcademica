import { useState } from "react";

function Postulaciones() {
  const [postulaciones, setPostulaciones] = useState([
    // Datos de ejemplo - reemplazar con datos reales
    {
      id: 1,
      userId: "001",
      firstName: "Juan",
      lastName: "Pérez",
      emailAddress: "juan@ejemplo.com",
      gender: "Masculino",
      phoneNumber: "123456789",
    },
  ]);

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Postulaciones</h1>
      <p className="mb-6">
        En esta página se mostrarán las postulaciones recibidas de posibles
        trabajadores. Solo los administradores podrán ver esta página.
      </p>

      <div className="overflow-x-auto">
        <table className="min-w-full bg-white border rounded-lg">
          <thead>
            <tr className="bg-gray-100">
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                ID
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Nombre
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Apellido
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Email
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Género
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Teléfono
              </th>
              <th className="px-6 py-3 border-b text-left text-xs font-semibold text-gray-600 uppercase">
                Acciones
              </th>
            </tr>
          </thead>
          <tbody>
            {postulaciones.map((postulacion) => (
              <tr key={postulacion.id} className="hover:bg-gray-50">
                <td className="px-6 py-4 border-b">{postulacion.userId}</td>
                <td className="px-6 py-4 border-b">{postulacion.firstName}</td>
                <td className="px-6 py-4 border-b">{postulacion.lastName}</td>
                <td className="px-6 py-4 border-b">
                  {postulacion.emailAddress}
                </td>
                <td className="px-6 py-4 border-b">{postulacion.gender}</td>
                <td className="px-6 py-4 border-b">
                  {postulacion.phoneNumber}
                </td>
                <td className="px-6 py-4 border-b">
                  <button
                    className="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600 mr-2"
                    onClick={() => console.log("Ver detalles", postulacion.id)}
                  >
                    Ver
                  </button>
                  <button
                    className="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600"
                    onClick={() => console.log("Aprobar", postulacion.id)}
                  >
                    Aprobar
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default Postulaciones;

// TODO: Separar la lista por elementos individuales para mantener el feature-driven development
