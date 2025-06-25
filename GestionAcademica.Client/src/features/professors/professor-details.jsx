import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { getProfessorById } from "../../services/ProfessorService";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";
import { getRoleLink } from "../../services/AuthService";
import Button from "../../components/button";

function ProfessorDetails() {
  const navigate = useNavigate();
  const { id } = useParams();
  const { userSession } = useAuthContext();
  const role = getRoleLink(userSession.roleId);

  const [professor, setProfessor] = useState({
    Id: id,
    Name: "",
    LastName: "",
    Address: "",
    PersonalEmail: "",
    InstitutionalEmail: "",
    PhoneNumber: "",
    BirthDate: "",
  });
  const getProfessor = async (id) => {
    const professorResponse = await getProfessorById(id);
    setProfessor({
      Name: professorResponse.name || "",
      LastName: professorResponse.lastName || "",
      Address: professorResponse.address || "",
      PersonalEmail: professorResponse.personalEmail || "",
      InstitutionalEmail: professorResponse.institutionalEmail || "",
      PhoneNumber: professorResponse.phoneNumber || "",
      BirthDate: professorResponse.birthDate || "",
    });
  };

  useEffect(() => {
    getProfessor(id);
  }, []);

  return (
    <div className="mx-auto p-4">
      <div className="flex flex-col w-2xl items-center justify-self-center">
        <h1 className="text-3xl font-bold mb-2">Detalles del Docente</h1>
        <p className="mb-9">Información detallada del docente seleccionado.</p>
        <div className="flex flex-col mb-4">
          <div className="flex flex-row mb-2">
            <p>
              <strong className="font-bold">Nombre Completo: </strong>
              {professor.Name} {professor.LastName}
            </p>
          </div>
          <div className="flex flex-row mb-2">
            <p>
              <strong className="font-bold">Dirección: </strong>
              {professor.Address}
            </p>
          </div>
          <div className="flex flex-row mb-2">
            <p>
              <label className="font-bold">Email Personal: </label>
              {professor.PersonalEmail}
            </p>
          </div>
          <div className="flex flex-row mb-2">
            <p>
              <label className="font-bold">Email Institucional: </label>
              {professor.InstitutionalEmail}
            </p>
          </div>
          <div className="flex flex-row mb-2">
            <p> 
            <label className="font-bold">Teléfono: </label>
              {professor.PhoneNumber}
            </p>
          </div>
          <div className="flex flex-row mb-2">
            <p>
            <label className="font-bold">Fecha de Nacimiento: </label>
              {professor.BirthDate}
            </p>
          </div>
          <Link
            to={`${role}/professors`}
            className="w-full text-center mt-4 text-blue-600 hover:underline font-semibold"
          >
            Volver
          </Link>
        </div>
      </div>
    </div>
  );
}

export default ProfessorDetails;
