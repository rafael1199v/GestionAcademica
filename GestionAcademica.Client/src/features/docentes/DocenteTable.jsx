
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import Button from "../../components/button";
import { getAllProfessors } from "../../services/AdministratorService";
import ItemDocente from "../lists/item-docente";

function DocenteTable() {
    const navigate = useNavigate();
      const [docentes, setDocentes] = useState([]);
  
      const fetchDocentes = async () => {
        try {
          const result = await getAllProfessors();
          setDocentes(result);
        } catch (error) {
          console.error("Error al obtener los docentes:", error);
        }
      }
  
  
      useEffect(() => {
        fetchDocentes();
      }, []);
  
    const handleNuevoDocente = () => {
      navigate("/registrar-docente");
    };
    return (
      <div>
        <h1>Docentes</h1>
        <p>Esta es la página de docentes.</p>
        <Button label="Nuevo docente" onClick={handleNuevoDocente} />
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
              <th scope="col" className="px-6 py-3">
                Estado
              </th>
              <th scope="col" className="px-6 py-3 w-1/8">
                {/* Acciones */}
              </th>
            </tr>
          </thead>
            <tbody>
              {docentes.map((docente) => (
                <ItemDocente key={docente.id} item={docente} />
              ))}
            </tbody>
          </table>
      </div>
    );
  }
  
  export default DocenteTable;