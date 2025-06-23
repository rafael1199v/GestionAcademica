import React from "react";
import ApplicationCardApplicant from "./components/application-card-applicant";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useAuthContext } from "../../hooks/UseAuthContext";
import applicationService from "../../services/ApplicationService";

function ApplicationsApplicant() {
  const navigate = useNavigate();
  const { userSession } = useAuthContext();
  const [applications, setApplications] = React.useState([]);

  const seeApplicationDetails = (id) => {
    navigate(`/applicant/applications/${id}`);
  };

  const fetchApplications = async () => {
    try {
      const result = await applicationService.getOwnApplications(userSession.userRoleId);

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
        Observa en esta página los estados de tus postulaciones.
      </p>
      <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
        {applications.map((application) => (
          <ApplicationCardApplicant
            key={application.id}
            item={application}
            onClick={() => seeApplicationDetails(application.id)}
          />
        ))}
      </ul>
    </div>
  );
}

export default ApplicationsApplicant;