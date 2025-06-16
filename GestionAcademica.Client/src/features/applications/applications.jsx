import React from 'react'
import ApplicationCard from './components/application-card'
import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react';
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from '../../config/role-const';
import { getRoleLink } from "../../services/AuthService";
import { getApplicationsByAdmin, 
        //  getApplicationById, 
         getApplicationsByApplicant, 
         getApplicationsByStatus, 
        //  getApplicationsByVacancy 
        } from '../../services/ApplicationService';

function Applications() {
  const navigate = useNavigate();
  const { userSession } = useAuthContext();
  const [applications, setApplications] = React.useState([]);
  const role = getRoleLink(parseInt(userSession.roleId));

  const seeApplicationDetails = (id) => {
    navigate(`${role}/applications/${id}`);
  }

  const fetchApplications = async () => {
    try {
      switch (parseInt(userSession.roleId)) {
        case ROLES.ADMIN:
          setApplications(getApplicationsByAdmin(userSession.userRoleId));
          break;

        case ROLES.HR:
          setApplications(getApplicationsByStatus(1));
          break;

        case ROLES.APPLICANT:
          setApplications(getApplicationsByApplicant(userSession.userRoleId));
          break;
          
        default:
          throw new Error("Error parsing applications");
      }
    }catch(e){
      window.Error(e);
    }
  }

  useEffect(() => {
    fetchApplications();
  }, []);

  return (
    <>
      <div className="flex flex-col gap-4">
        <h1 className="text-4xl">Postulaciones</h1>
        <p className="text-xl">
          En esta página pueden verse tus postulaciones entrantes con sus estados
        </p>
        <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
          {applications.map((application) => (
            <ApplicationCard 
              key={application.Id}
              title={application.VacancyName}
              content={application.VacancyDesc}
              state={application.Status}
              onClick={() => seeApplicationDetails(application.Id)}
            />
          ))}
        </ul>
      </div>

    </>
  )
}

export default Applications