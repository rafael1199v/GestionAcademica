import { useEffect, useState } from "react"
import hrService from "../services/HrService";
import { useParams } from "react-router-dom";

export const useApplicationDetailsHr = () => {
    const [application, setApplication] = useState(null);
    const { id } = useParams();

    const getApplicationDetail = async () => {
        const data = await hrService.getById(id);
        
        console.log(data);
        setApplication(data);
    }

    useEffect(() => {
       getApplicationDetail();
    }, [id]);


    return { application };
}