import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getApplicationById, updateApplication } from "../../services/ApplicationService";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";
import { getRoleLink } from "../../services/AuthService";

function ApplicationDetail() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);
  const { userSession } = useAuthContext();
  const navigate = useNavigate();
  const roleLink = getRoleLink(userSession.roleId);

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

  const approveApplication = async (data) => {
    const request = {
      vacancyName: data.vacancyName,
      vacancyDesc: data.vacancyDesc,
      status: data.status == "En Revision" ? "Entrevista" : "Aceptado",
      applicantName: data.applicantName,
      ownerName: data.ownerName,
      fileQtty: data.fileQtty,
      // file handling here, pls
      id: data.id,
      vacancyId: data.vacancyId,
      statusId: data.statusId < 3 ? data.statusId + 1 : 3,
      applicantId: data.applicantId,
      ownerId: data.ownerId,
    };
    try {
      await updateApplication(request);
      window.alert("Solicitud enviada");
      navigate(roleLink + "/applications");
    } catch (err) {
      window.alert("Hubo un error con la solicitud...");
      console.error(err.message);
    }
  };

  const rejectApplication = async (data) => {
    const request = {
      vacancyName: data.vacancyName,
      vacancyDesc: data.vacancyDesc,
      status: "Rechazado",
      applicantName: data.applicantName,
      ownerName: data.ownerName,
      fileQtty: data.fileQtty,
      // file handling here 2, pretty please
      id: data.id,
      vacancyId: data.vacancyId,
      statusId: 4,
      applicantId: data.applicantId,
      ownerId: data.ownerId,
    };
    try {
      await updateApplication(request);
      window.alert("Solicitud enviada");
      navigate(roleLink + "/applications");
    } catch (err) {
      window.alert("Hubo un error con la solicitud...");
      console.error(err.message);
    }
  };

  useEffect(() => {
    fetchApplication();
  }, []);

  const getStatusColor = (statusId) => {
    switch (parseInt(statusId)) {
      case 1:
        return "bg-gray-100 text-gray-800";
      case 2:
        return "bg-yellow-100 text-yellow-800";
      case 3:
        return "bg-green-100 text-green-800";
      case 4:
        return "bg-red-100 text-red-800";
      default:
        return "bg-gray-300 text-gray-800";
    }
  };

  const getMessage = (statusId) => {
    switch (parseInt(statusId)) {
      case 1:
        return "Hemos recibido tu curriculum. Pronto recibirás una respuesta";
      case 2:
        return "El agente de recursos humanos a aceptado tu curriculum. Genial!!!. Se te hablará por teléfono para coordinar una entrevista";
      case 3:
        return "Felicidades, has sido aceptado. Te hablaremos lo mas rapido que podamos. Bienvenido";
      case 4:
        return "Lo siento. Como organización agradecemos que hayas presentado tu postulación. No dudes que volveremos a contactarte!!!";
      default:
        return "Hubo un problema al obtener los datos de la postulación, intente nuevamente...";
    }
  };

  if (!application) {
    return (
      <div className="flex justify-center items-center min-h-screen">
        <p className="text-gray-500">Cargando detalles...</p>
      </div>
    );
  }

  if (userSession.roleId != ROLES.ADMIN && userSession.roleId != ROLES.HR) {
    return (
      <div className="max-w-4xl mx-auto px-4 py-8">
        <div className="bg-white shadow-md rounded-lg p-6 dark:bg-gray-800 dark:text-white">
          <h1 className="text-3xl font-bold mb-2">{application.vacancyName}</h1>
          <h3 className="text-xl mb-2">
            Ofrecido por: {application.ownerName}
          </h3>

          <span
            className={`inline-block px-3 py-1 text-sm font-medium rounded-full ${getStatusColor(
              application.statusId
            )}`}
          >
            Estado: {application.status}
          </span>

          <p className="mt-4 text-gray-700 dark:text-gray-300">
            {application.vacancyDesc}
          </p>

          <p className="mt-4 text-gray-500 dark:text-gray-300">
            {getMessage(application.statusId)}
          </p>

          <div className="mt-6">
            <button className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition">
              Descargar Archivos
            </button>
          </div>
        </div>
      </div>
    );
  } else {
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
          <div>
            <strong>Estado:</strong> {application?.status} (
            {application?.statusId})
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
              approveApplication(application);
            }}
          >
            Aceptar
          </button>
          <button
            className="flex items-center gap-2 bg-red-500 text-white px-4 py-2 rounded-xl hover:bg-red-600 active:scale-95 shadow-md transition cursor-pointer"
            onClick={() => {
              rejectApplication(application);
            }}
          >
            Rechazar
          </button>
        </div>
      </div>
    );
  }
}

export default ApplicationDetail;