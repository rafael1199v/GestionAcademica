import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import vacancyService from "../../services/VacancyService";
import { useEffect, useState } from "react";

function VacanciesAdmin() {
  const [vacancies, setVacancies] = useState([]);
  const navigate = useNavigate();

  const getVacancies = async() => {
    try {
      const data = await vacancyService.getVacancies(localStorage.getItem('userId'));
      console.log(data);
      setVacancies(data);
    }
    catch(error) {
      console.error(error.message);
    }
  }

  useEffect(() => {
    getVacancies();
  }, []);

  return (
    <>
      <h1 className="text-2xl">Vacantes</h1>
      
      <button
        type="button"
        className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800"
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
              Materia
            </th>
            <th scope="col" className="px-6 py-3">
              Vigente
            </th>
            <th scope="col" className="px-6 py-3 w-1/8">
              Acciones
            </th>
          </tr>
        </thead>
        <tbody>
          { vacancies.map(vacancy => (
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200 hover:bg-gray-50 dark:hover:bg-gray-600" key={vacancy.id}>
              <td className="px-6 py-4">{vacancy.name}</td>
              <td className="px-6 py-4">{vacancy.careerName}</td>
              <td className="px-6 py-4">{vacancy.subjectName}</td>
              <td className="px-6 py-4">
                <div className="flex items-center">
                  <div className={`h-2.5 w-2.5 rounded-full ${ vacancy.closed ? 'bg-red-500 me-2' : 'bg-green-500 me-2'}`}></div>
                  {vacancy.closed ? "Finalizado" : "Vigente"}
                </div>
              </td>
              <td className="px-6 py-3 flex justify-between gap-2">
                <Link
                  to={`/`}
                  className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
                >
                  Postulaciones
                </Link>

                <Link
                  to={`/vacancies/update/${vacancy.id}`}
                  className="font-medium text-blue-600 dark:text-blue-500 hover:underline"
                >
                  Editar
                </Link>
                <a className='text-red-500 cursor-pointer hover:underline' onClick={async () => {
                  await vacancyService.deleteVacancy(vacancy.id);
                  await getVacancies();
                }}>
                  Eliminar
                </a>
              </td>
            </tr>
          ))}
          
        </tbody>
      </table>
    </>
  );
}
// TODO: crear vacantes
export default VacanciesAdmin;
