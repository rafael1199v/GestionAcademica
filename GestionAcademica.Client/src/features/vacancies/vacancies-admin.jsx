import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import vacancyService from "../../services/VacancyService";
import { useEffect, useState } from "react";
import Button from "../../components/button";

function VacanciesAdmin() {
  const [vacancies, setVacancies] = useState([]);
  const navigate = useNavigate();

  const getVacancies = async () => {
    try {
      const data = await vacancyService.getVacancies(
        localStorage.getItem("userId")
      );
      setVacancies(data);
    } catch (error) {
      console.error(error.message);
    }
  };

  useEffect(() => {
    getVacancies();
  }, []);

  return (
    <>
      <h1 className="text-center w-full text-3xl font-bold text-gray-800 mb-4">Vacantes</h1>
      <p className="mb-4 text-center">Crea y administra vacantes a las cuales cualquier persona puede postular.</p>
      <div className="w-full justify-center flex">
      <Button
      label="Crear vacante"
        onClick={() => navigate("/vacancies/create")}
      />
      </div>
      <table className="mt-3 w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400 shadow-md">
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
          {vacancies.map((vacancy) => (
            <tr
              className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200 hover:bg-gray-50 dark:hover:bg-gray-600"
              key={vacancy.id}
            >
              <td className="px-6 py-4">{vacancy.name}</td>
              <td className="px-6 py-4">{vacancy.careerName}</td>
              <td className="px-6 py-4">{vacancy.subjectName}</td>
              <td className="px-6 py-4">
                <div className="flex items-center">
                  <div
                    className={`h-2.5 w-2.5 rounded-full ${
                      vacancy.closed ? "bg-red-500 me-2" : "bg-green-500 me-2"
                    }`}
                  ></div>
                  {vacancy.closed ? "Finalizado" : "Vigente"}
                </div>
              </td>
              <td className="px-6 py-3 flex justify-between gap-2">
                <Link
                  to={`/vacancies/${vacancy.id}`}
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
                <a
                  className="text-red-500 cursor-pointer hover:underline"
                  onClick={async () => {
                    await vacancyService.deleteVacancy(vacancy.id);
                    await getVacancies();
                  }}
                >
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
