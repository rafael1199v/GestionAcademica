import React from "react";
import { useAuthContext } from "../hooks/UseAuthContext";
import { ROLES } from "../config/role-const";
import { Link } from 'react-router-dom';
import { getRoleLink } from "../services/AuthService";

function Home() {
    const { userSession } = useAuthContext();
    const role = userSession.roleId;
    return (
        <div className="container mx-auto p-4">
            <header className="text-center mb-8">
                <h1 className="text-3xl font-bold mb-2">Gestión Académica Universitaria</h1>
                <p className="text-gray-600">
                    Consulta información sobre docentes y vacantes disponibles en la universidad.
                </p>
            </header>
            <section className="flex flex-wrap justify-center gap-8">
                <div className="flex-1 min-w-[250px] max-w-xs border border-gray-200 rounded-lg p-6 bg-gray-50 shadow-sm">
                    <h2 className="text-xl font-semibold mb-2">Docentes</h2>
                    <p className="text-gray-700 mb-4">Consulta {role==ROLES.ADMIN? "y edita":""} el listado de docentes, sus perfiles y áreas de especialización.</p>
                    <Link to={`${getRoleLink(role)}/professors`} className="mt-2 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition">Ver docentes</Link>
                </div>
                <div className="flex-1 min-w-[250px] max-w-xs border border-gray-200 rounded-lg p-6 bg-gray-50 shadow-sm">
                    <h2 className="text-xl font-semibold mb-2">Postulaciones</h2>
                    <p className="text-gray-700 mb-4">
                        {role!=ROLES.APPLICANT
                        ? "Observa las postulaciones entrantes y los archivos recibidos de cada posible candidato a docente." 
                        : "Haz seguimiento de las postulaciones que has enviado, revisa si fuiste aceptdo o no en alguna."
                        }
                    </p>
                    <Link to={`${getRoleLink(role)}/applications`} className="mt-2 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition">Ver postulaciones</Link>
                </div>
                {role != ROLES.HR && (
                <div className="flex-1 min-w-[250px] max-w-xs border border-gray-200 rounded-lg p-6 bg-gray-50 shadow-sm">
                    <h2 className="text-xl font-semibold mb-2">Vacantes</h2>
                    <p className="text-gray-700 mb-4">
                        {role==ROLES.ADMIN
                        ? "Administra las vacantes y revisa las nuevas postulaciones recibidas por posibles candidatos a docente." 
                        : "Postúlate a vacantes abiertas por los directores de carrera y forma parte del equipo docente."
                        }
                    </p>
                    <Link to={`${getRoleLink(role)}/vacancies`} className="mt-2 px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 transition">Ver vacantes</Link>
                </div>
                )}
            </section>
            <footer className="text-center mt-8 text-gray-500">
                <small>© {new Date().getFullYear()} Gestión Académica. Todos los derechos reservados.</small>
            </footer>
        </div>
    );
}

export default Home;