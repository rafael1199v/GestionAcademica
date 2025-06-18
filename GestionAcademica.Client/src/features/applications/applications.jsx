import React from "react";
import ApplicationCard from "./components/application-card";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";
import { getRoleLink } from "../../services/AuthService";
import {
  getApplicationsByAdmin,
  getApplicationsByApplicant,
  getApplicationsByStatus,
} from "../../services/ApplicationService";

function Applications() {
  const navigate = useNavigate();
  const { userSession } = useAuthContext();
  const [applications, setApplications] = React.useState([]);
  const role = getRoleLink(userSession.roleId);

  const seeApplicationDetails = (id) => {
    navigate(`${role}/applications/${id}`);
  };

  const fetchApplications = async () => {
    try {
      let result;
      switch (parseInt(userSession.roleId)) {
        case ROLES.ADMIN:
          result = await getApplicationsByAdmin(userSession.userRoleId);
          break;

        case ROLES.HR:
          result = await getApplicationsByStatus(1);
          break;

        case ROLES.APPLICANT:
          result = await getApplicationsByApplicant(userSession.userRoleId);
          break;

        default:
          throw new Error("Error parsing applications");
      }
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
        En esta página pueden verse tus postulaciones entrantes con sus estados
      </p>
      <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
        {applications.map((application) => (
          <ApplicationCard
            key={application.id}
            item={application}
            role={parseInt(userSession.roleId)}
            onClick={() => seeApplicationDetails(application.id)}
          />
        ))}
      </ul>
    </div>
  );
}

export default Applications;