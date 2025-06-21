import React from "react";
import ApplicationCardHr from "./components/application-card-hr";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { getApplicationsByStatus } from "../../services/ApplicationService";
import { STATUS } from "../../config/status-const";
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
      <h1 className="text-4xl">Postulaciones</h1>
      <p className="text-xl">
        En esta página pueden verse las postulaciones entrantes con sus estados
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