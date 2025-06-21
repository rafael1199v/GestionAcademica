import React from "react";
import ApplicationCardAdmin from "./components/application-card-admin";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { getApplicationsByAdmin } from "../../services/ApplicationService";
import { useParams } from "react-router-dom";
import applicationService from "../../services/ApplicationService";

function ApplicationsAdmin() {
  const navigate = useNavigate();
  const { userSession } = useAuthContext();
  const [applications, setApplications] = React.useState([]);
  const { id } = useParams();

  const seeApplicationDetails = (applicationId) => {
    navigate(`/applications/${applicationId}`);
  };

  const fetchApplications = async () => {
    try {
      const result = await applicationService.getSubmittedApplications(id);
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
      <h1 className="text-4xl">Postulaciones</h1>
      <p className="text-xl">
        Aquí puedes ver las postulaciones ya verificadas por Recursos Humanos para las vacantes de su carrera.
      </p>
      <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
        {applications.map((application) => (
          <ApplicationCardAdmin
            key={application.id}
            item={application}
            onClick={() => seeApplicationDetails(application.id)}
          />
        ))}
      </ul>
    </div>
  );
}

export default ApplicationsAdmin;