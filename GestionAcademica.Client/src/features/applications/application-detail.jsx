import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

function ApplicationDetail() {
  const { id } = useParams();
  const [application, setApplication] = useState(null);

  const fetchApplication = async () => {
    const data = {
      title: "Título de la aplicación",
      description: "Esta es una descripción más detallada de la aplicación del postulante. Aquí podrías incluir comentarios, requisitos o información adicional.",
      state: "Rechazado"
    };

    setApplication(data);
  };

  useEffect(() => {
    fetchApplication();
  }, []);

  const getStatusColor = (state) => {
    switch (state) {
      case 'Entrevista':
        return 'bg-yellow-100 text-yellow-800';
      case 'En revision':
        return 'bg-gray-100 text-gray-800'
      case 'Aceptado':
        return 'bg-green-100 text-green-800';
      case 'Rechazado':
        return 'bg-red-100 text-red-800';
      default:
        return 'bg-gray-100 text-gray-800';
    }
  };

  const getMessage = (state) => {
     switch (state) {
      case 'Entrevista':
        return 'El agente de recursos humanos a aceptado tu curriculum. Genial!!!. Se te hablará por teléfono para coordinar una entrevista';
      case 'En revision':
        return 'Hemos recibido tu curriculum. Pront recibiras una respuesta'
      case 'Aceptado':
        return 'Felicidades, has sido aceptado. Te hablaremos lo mas rapido que podamos. Bienvenido';
      case 'Rechazado':
        return 'Lo siento. Como organización agradecemos que hayas presentado tu postulación. No dudes que volveremos a contactarte!!!';
      default:
        return 'bg-gray-100 text-gray-800';
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
        <h1 className="text-3xl font-bold mb-2">{application.title}</h1>

        <span className={`inline-block px-3 py-1 text-sm font-medium rounded-full ${getStatusColor(application.state)}`}>
          Estado: {application.state}
        </span>

        <p className="mt-4 text-gray-700 dark:text-gray-300">
          {application.description}
        </p>

        <p className="mt-4 text-gray-500 dark:text-gray-300">
          {getMessage(application.state)}
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

export default ApplicationDetail;
