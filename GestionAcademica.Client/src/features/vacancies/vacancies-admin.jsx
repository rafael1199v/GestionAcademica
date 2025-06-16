import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

function VacanciesAdmin() {
  const navigate = useNavigate();

  return (
    <>
      <h1 className="text-2xl">Vacantes</h1>
      
      <button
        type="button"
        class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800"
        onClick={() => navigate("/vacancies/create")}

      >
        Crear vacante
      </button>

      <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400 shadow-md">
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th scope="col" className="px-6 py-3">
              Nombre
            </th>
            <th scope="col" className="px-6 py-3">
              Carrera
            </th>
            <th scope="col" className="px-6 py-3">
              Administrador
            </th>
            <th scope="col" className="px-6 py-3">
              Teléfono
            </th>
            {/* <th scope="col" className="px-6 py-3">
              Estado
            </th> */}
            <th scope="col" className="px-6 py-3 w-1/8">
              {/* Acciones */}
            </th>
          </tr>
        </thead>
        <tbody>

        </tbody>
      </table>
    </>
  );
}
// TODO: crear vacantes
export default VacanciesAdmin;
