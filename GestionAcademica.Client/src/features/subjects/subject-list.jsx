import SubjectItem from "./subject-item";
import { useNavigate } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { getAllSubjects } from "../../services/AdministratorService";

function Subjects(){

    const [subjects, setSubjects] = useState([]);
    const loadSubjects = async () => {
        try {
            const subjectsList = await getAllSubjects();
            setSubjects(subjectsList);
        } catch (error) {
            console.error("Error al cargar las materias:", error);
        }
    };
    useEffect(() => {
        loadSubjects();
    }, []);

    const navigate = useNavigate();
    return(
        <div>
            <h1 className="text-center w-full text-3xl font-bold text-gray-800 mb-4">Materias</h1>
            <p className="text-center">Esta es la página de materias a las que está inscrita un docente.</p>
            <p className="text-center">Los administradores deben tener la opción de ver todas las materias y registrar nuevas de ser necesario.</p>
            <div className="p-5"></div>
            <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">
                {subjects.map((subject) => (
                    <SubjectItem 
                        key={subject.id} 
                        title={subject.name} 
                        description={subject.description} 
                        onClick={() => navigate(`/subject-details/${subject.id}`)} 
                    />
                ))}
            </ul>
        </div>
    )
}

export default Subjects;