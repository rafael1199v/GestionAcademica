import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import Button from "../../components/button";
import { getAllProfessors } from "../../services/AdministratorService";
import ProfessorItem from "./components/professor-item";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";

function ProfessorTable() {
  const { userSession } = useAuthContext();
  const navigate = useNavigate();
  const [professors, setProfessors] = useState([]);

  const fetchProfessors = async () => {
    try {
      const result = await getAllProfessors();
      setProfessors(result);
    } catch (error) {
      console.error("Error al obtener los docentes:", error);
    }
  };

  useEffect(() => {
    fetchProfessors();
  }, []);

  const handleNuevoDocente = () => {
    navigate("/create-professor");
  };
  return (
    <div>
      <h1 className="text-3xl font-bold text-gray-800 mb-4 text-center w-full">Docentes</h1>
      <p className="text-center block mb-2">Aquí puedes observar la lista de todos los docentes que están trabajando en la universidad actualmente, para más información, haga click en los detalles de cualquier docente. Un administrador también puede crear y actualizar los datos de un docente.</p>
      {userSession.roleId == ROLES.ADMIN && (
        <div className="w-full justify-center flex">
          <Button label="Nuevo docente" onClick={handleNuevoDocente} />
        </div>
      )}
      <table className="mt-5 w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400 shadow-md">
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th scope="col" className="px-6 py-3">
              Nombre completo
            </th>
            <th scope="col" className="px-6 py-3">
              Dirección
            </th>
            <th scope="col" className="px-6 py-3">
              Email
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
          {professors.map((docente) => (
            <ProfessorItem key={docente.id} item={docente} />
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProfessorTable;
