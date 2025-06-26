import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import applicationService from "../../services/ApplicationService";
import fileService from "../../services/FileService";

function ApplicationDetailApplicant() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);

  const fetchApplication = async () => {
    const data = await applicationService.getApplicationDetailForApplicant(id);
    // Replace with actual file handling ASAP
    setApplication(data);
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
      case 1002:
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
      case 1002:
        return "Se ha recibido tu postulación, sin embargo, el sistema indica que tienes una dificultad en la institución, pero no se preocupe, está en buenas manos.";
      // case 1003:
      //   return "El agente de recursos humanos a aceptado tu curriculum. Genial!!!. Se te hablará por teléfono para coordinar una entrevista";
      default:
        return "Hubo un problema al obtener los datos de la postulación, intente nuevamente...";
    }
  };


  const downloadFile = async(fileId, fileName, fileExtension) => {
    try {
      await fileService.downloadFile(fileId, fileName, fileExtension);
    }
    catch(error) {
      alert("No se pudo descargar el archivo");
    }
  }

  if (!application) {
    return (
      <div className="flex justify-center items-center min-h-screen">
        <p className="text-gray-500">Cargando detalles...</p>
      </div>
    );
  }

  return (
    <div className="max-w-4xl mx-auto px-4 py-8">
      <div className="bg-white shadow-md rounded-lg p-6 dark:bg-gray-800 dark:text-white">
        <h1 className="text-3xl font-bold mb-2">{application.vacancyName}</h1>
        <h3 className="text-xl mb-2">Ofrecido por: {application.administratorName}</h3>
        <div className="grid grid-cols-2 gap-4 pb-5">
          <div>
            <strong>Materia: </strong> {application?.vacancySubjectName}
          </div>
          <div>
            <strong>Carrera: </strong> {application?.vacancyCareerName}
          </div>
        </div>

        <span
          className={`inline-block px-3 py-1 text-sm font-medium rounded-full ${getStatusColor(
            application.statusId
          )}`}
        >
          Estado: {applicationService.getStatusName(application.statusId)}
        </span>

        <p className="mt-4 text-gray-700 dark:text-gray-300">
          {application.vacancyDesc}
        </p>

        <p className="mt-4 text-gray-500 dark:text-gray-300">
          {getMessage(application.statusId)}
        </p>

        <div>
          <h2 className="text-lg font-semibold mt-6 mb-2">Archivos enviados:</h2>
          <ul className="space-y-2">
            {application?.files.map((file) => (
              <li
                key={file.id}
                className="flex justify-between items-center bg-gray-100 dark:bg-gray-900 px-4 py-2 rounded-lg"
              >
                <span>
                  {file.name}
                  {file.extension}
                </span>
                <button className="text-blue-600 hover:underline text-sm cursor-pointer" onClick={() => {
                  downloadFile(file.id, file.name, file.extension);
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
      </div>
    </div>
  );
}

export default ApplicationDetailApplicant;
