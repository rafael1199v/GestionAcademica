import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  getApplicationById,
  updateAppStatus,
} from "../../services/ApplicationService";
import { STATUS } from "../../config/status-const";
import applicationService from "../../services/ApplicationService";
import fileService from "../../services/FileService";


function ApplicationDetailAdmin() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);
  const navigate = useNavigate();

  const fetchApplication = async () => {
    let data = await applicationService.getDetailInterviewApplication(id);
    setApplication(data);
  };
  
  const rejectApplication = async() => {
    try {
      await applicationService.rejectApplicationByAdmin(id);
      alert("Postulacion rechazada correctamente");
    }
    catch(error) {
      alert("Hubo un error al rechazar la postulacion");
    }
  }

  const hireApplicant = async() => {
    try {
      const newProfessor = await applicationService.hireApplicant(id);
      alert("Postulante contratado");
      navigate(`/create-professor`, { state: { newProfessor: newProfessor } });
    }
    catch(error) {
      alert(error.message);
    }
  }

 
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
          <strong>Administrador:</strong> {application?.administratorName}
        </div>
        <div>
          <strong>Materia: </strong> {application?.vacancyCareerName}
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
              <button className="text-blue-600 hover:underline text-sm cursor-pointer" onClick={() => {
                fileService.downloadFile(file.id, file.name, file.extension)
              }}>
                Ver archivo
              </button>
            </li>
          ))}
        </ul>
      </div>
      <div className="flex justify-end space-x-4 mt-6">
        <button
          className="flex items-center gap-2 bg-green-500 text-white px-4 py-2 rounded-xl hover:bg-green-600 active:scale-95 shadow-md transition cursor-pointer disabled:opacity-30"
          onClick={() => {
           hireApplicant();
          }}
          disabled={application?.statusId == STATUS.REJECTED || application.statusId == STATUS.APPROVED}
        >
          Aceptar
        </button>
        <button
          className="flex items-center gap-2 bg-red-500 text-white px-4 py-2 rounded-xl hover:bg-red-600 active:scale-95 shadow-md transition cursor-pointer disabled:opacity-30"
          onClick={async () => {
            await rejectApplication();
            await fetchApplication();
          }}
          disabled={application?.statusId == STATUS.REJECTED || application.statusId == STATUS.APPROVED}

        >
          Rechazar
        </button>
      </div>
    </div>
  );
}

export default ApplicationDetailAdmin;
