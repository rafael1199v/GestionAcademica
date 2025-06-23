import React from "react";
import ApplicationCardHr from "./components/application-card-hr";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import applicationService from "../../services/ApplicationService";

function ApplicationsHr() {
  const navigate = useNavigate();
  const [applications, setApplications] = React.useState([]);

  const seeApplicationDetails = (id) => {
    navigate(`/hr/applications/${id}`);
  };

  const fetchApplications = async () => {
    try {
      const result = await applicationService.getNewApplications();
      setApplications(result);
    } catch (e) {
      window.Error(e);
    }
  };

  useEffect(() => {
    fetchApplications();
  }, []);

  return (
    <div className="flex flex-col gap-4">
      <h1 className="text-3xl font-bold text-gray-800 mb-4 text-center w-full">Postulaciones</h1>
      <p className="text-xl text-center">
        Aquí puedes ver las postulaciones entrantes a cualquier materia. Como miembro de Recursos Humanos, tu trabajo es verificar la información y rechazar las solicitudes o ascenderlas hacia el administrador.
      </p>
      <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
        {applications.map((application) => (
          <ApplicationCardHr
            key={application.id}
            item={application}
            onClick={() => seeApplicationDetails(application.id)}
          />
        ))}
      </ul>
    </div>
  );
}

export default ApplicationsHr;