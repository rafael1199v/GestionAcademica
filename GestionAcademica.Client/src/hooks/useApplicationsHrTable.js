import { useEffect, useState } from "react"
import HrService from '../services/HrService'
import { useNavigate } from "react-router-dom";


export const useApplicationsHrTable = () => {
    const [applications, setApplications] = useState([]);
    const navigate = useNavigate();

    const seeApplicationDetails = (id) => {
        navigate(`/hr/applications/${id}`);
    }
    
    const getApplications = async () => {
        const data = await HrService.getApplications();
        setApplications(data);
    }

    useEffect(() => {
        getApplications();
    }, []);

    return { applications, seeApplicationDetails };
}