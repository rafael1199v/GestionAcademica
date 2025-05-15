import ItemDocente from "../features/lists/item-docente";
import Button from "../components/button";
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { getAllProfessors } from "../services/AdministratorService";

function Docentes() {
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
    navigate("/docentes/nuevo");
  };
  return (
    <div>
      <h1>Docentes</h1>
      <p>Esta es la página de docentes.</p>
      <Button label="Nuevo docente" onClick={handleNuevoDocente} />
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

export default Docentes;

// TODO: Configurar la tabla según los campos de la base de datos