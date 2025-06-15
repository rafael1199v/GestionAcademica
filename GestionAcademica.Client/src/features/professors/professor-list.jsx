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
      <h1>Docentes</h1>
      <p>Esta es la página de docentes.</p>
      {userSession.roleId == ROLES.ADMIN && (
        <Button label="Nuevo docente" onClick={handleNuevoDocente} />
      )}
      <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400 shadow-md">
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
