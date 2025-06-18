import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getApplicationById } from "../../services/ApplicationService";

function ApplicationDetailApplicant() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);

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

  return (
    <div className="max-w-4xl mx-auto px-4 py-8">
      <div className="bg-white shadow-md rounded-lg p-6 dark:bg-gray-800 dark:text-white">
        <h1 className="text-3xl font-bold mb-2">{application.vacancyName}</h1>
        <h3 className="text-xl mb-2">Ofrecido por: {application.ownerName}</h3>

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
}

export default ApplicationDetailApplicant;
