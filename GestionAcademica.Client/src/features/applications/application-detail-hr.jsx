import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  getApplicationById,
  updateAppStatus,
} from "../../services/ApplicationService";
import { STATUS } from "../../config/status-const";

function ApplicationDetailHr() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);
  const navigate = useNavigate();

  const fetchApplication = async () => {
    let data = await getApplicationById(id);
    data = {
      ...data,
      files: [
        {
          id: 1,
          name: "Curriculum",
          extension: ".docx",
        },
        {
          id: 2,
          name: "Certificacion AWS",
          extension: ".pdf",
        },
      ],
    };
    // Replace with actual file handling ASAP
    setApplication(data);
  };

  const handleAction = async (id, newStatus) => {
    const request = {
      id: id,
      status: newStatus,
    };
    try {
      await updateAppStatus(request);
      window.alert(
        newStatus == STATUS.APPROVED
          ? "Solicitud aprobada exitosamente"
          : "Solicitud rechazada exitosamente"
      );
      navigate("/hr/applications");
    } catch (err) {
      window.alert("Hubo un error con la solicitud...");
      console.error(err.message);
    }
  };

  useEffect(() => {
    fetchApplication();
  }, []);

  if (!application) {
    return (
      <div className="flex justify-center items-center min-h-screen">
        <p className="text-gray-500">Cargando detalles...</p>
      </div>
    );
  }
  return (
    <div className="max-w-3xl mx-auto mt-10 bg-white shadow-xl rounded-2xl p-6 space-y-6">
      <h1 className="text-2xl font-bold text-gray-800">
        Detalles de Solicitud
      </h1>

      <div className="grid grid-cols-2 gap-4 text-gray-700">
        <div>
          <strong>Solicitante:</strong> {application?.applicantName}
        </div>
        <div>
          <strong>Administrador:</strong> {application?.ownerName}
        </div>
      </div>

      <div>
        <h2 className="text-lg font-semibold mt-6 mb-2">Archivos</h2>
        <ul className="space-y-2">
          {application?.files.map((file) => (
            <li
              key={file.id}
              className="flex justify-between items-center bg-gray-100 px-4 py-2 rounded-lg"
            >
              <span>
                {file.name}
                {file.extension}
              </span>
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
          onClick={() => {
            handleAction(application.id, STATUS.APPROVED);
          }}
        >
          Aceptar
        </button>
        <button
          className="flex items-center gap-2 bg-red-500 text-white px-4 py-2 rounded-xl hover:bg-red-600 active:scale-95 shadow-md transition cursor-pointer"
          onClick={() => {
            handleAction(application.id, STATUS.REJECTED);
          }}
        >
          Rechazar
        </button>
      </div>
    </div>
  );
}

export default ApplicationDetailHr;
