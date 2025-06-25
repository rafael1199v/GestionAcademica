import React, { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { STATUS } from "../../config/status-const";
import applicationService from "../../services/ApplicationService";
import fileService from "../../services/FileService";

function ApplicationDetailHr() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);
  const navigate = useNavigate();

  const fetchApplication = async () => {
    const data = await applicationService.getApplicationDetailForHr(id);
    setApplication(data);
  };

  const rejectApplication = async (id) => {
    try {
      await applicationService.rejectApplication(id);
      alert("Solicitud rechazada correctamente");

      navigate(`/hr/applications`)
    }
    catch(err) {
      alert("Hubo un error al actualizar al solicitud");
      console.error(error.message);
    }
  }

  const uploadApplicationToInterview = async(id) => {
    try {
      await applicationService.uploadApplicationToInterview(id);
      alert("Solicitud aprobada existosamente");
      navigate(`/hr/applications`)
    }
    catch(err) {
      alert("Hubo un error al actualizar al solicitud");
      console.error(error.message);
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

      <div className="grid grid-cols-2 gap-4 text-gray-700 pb-5">
        <div>
          <strong>Materia: </strong> {application?.vacancySubjectName}
        </div>
        <div>
          <strong>Carrera: </strong> {application?.vacancyCareerName}
        </div>
        <div>
          <strong>Estado: </strong> {applicationService.getStatusName(application?.statusId)}
        </div>
      </div>
      <strong className="block text-xl font-bold text-gray-800">Datos del solicitante:</strong>
      <div className="grid grid-cols-2 gap-5 text-gray-700">
        <div>
          <strong>Nombre: </strong> {application?.user?.name}
        </div>
         <div>
          <strong>Apellido: </strong> {application?.user?.lastName}
        </div>
        <div>
          <strong>Direccion: </strong> {application?.user?.address}
        </div>
        <div>
          <strong>Correo: </strong> {application?.user?.institutionalEmail}
        </div>
        <div>
          <strong>Teléfono: </strong> {application?.user?.phoneNumber}
        </div>
        <div>
          <strong>Fecha de nacimiento: </strong> {application?.user?.birthDate}
        </div>
      </div>

      <div>
        <strong className="block text-gray-700 mb-3">Archivos:</strong>
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
                fileService.downloadFile(file.id, file.name, file.extension);
              }}>
                Ver archivo
              </button>
            </li>
          ))}

          { application?.files.length === 0 && (
            <p>El postulante no ha subido archivos</p>
          )}
        </ul>
      </div>
      <div className="flex justify-between">
        <Link
        className="space-x-4 mt-6 px-4 py-2 text-blue-600 hover:underline font-semibold"
        to="/hr/applications">
          Volver
        </Link>
        <div className="flex space-x-4 mt-6">
          <button
            className="flex items-center gap-2 bg-green-500 text-white px-4 py-2 rounded-xl hover:bg-green-600 active:scale-95 shadow-md transition cursor-pointer disabled:opacity-30 disabled:bg-green-500 disabled:cursor-not-allowed"
            onClick={() => {
              uploadApplicationToInterview(id);
            }}
          >
            Aceptar
          </button>
          <button
            className="flex items-center gap-2 bg-red-500 text-white px-4 py-2 rounded-xl hover:bg-red-600 active:scale-95 shadow-md transition cursor-pointer disabled:opacity-30 disabled:hover:bg-red-500 disabled:cursor-not-allowed"
            onClick={() => {
              rejectApplication(id);
            }}
          >
            Rechazar
          </button>
        </div>
      </div>
    </div>
  );
}

export default ApplicationDetailHr;
