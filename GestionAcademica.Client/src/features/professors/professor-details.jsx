import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { getProfessorById } from "../../services/AdministratorService";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";

function ProfessorDetails() {
  const navigate = useNavigate();
  const { id } = useParams();
  const { userSession } = useAuthContext();
  const getRole = () => {
    switch (parseInt(userSession.roleId)) {
      case ROLES.ADMIN:
        return "";
        break;
      case ROLES.PROFESSOR:
        return "/professor";
        break;
      case ROLES.STUDENT:
        return "/student";
        break;
      case ROLES.APPLICANT:
        return "/applicant";
        break;
      case ROLES.HR:
        return "/hr";
        break;

      default:
        return "error";
        break;
    }
  };
  const role = getRole();

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
    <div>
      <h1 class="text-xl">Detalles del Docente</h1>
      <p>Información detallada del docente seleccionado.</p>
      <div class="mb-9"></div>
      <div class="flex flex-col mb-4">
        <div class="flex flex-row mb-2">
          <label>Nombre Completo:</label>
          <p>
            {" "}
            {professor.Name} {professor.LastName}
          </p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Dirección:</label>
          <p> {professor.Address}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Email Personal:</label>
          <p> {professor.PersonalEmail}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Email Institucional:</label>
          <p> {professor.InstitutionalEmail}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Teléfono</label>
          <p> {professor.PhoneNumber}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Fecha de Nacimiento:</label>
          <p> {professor.BirthDate}</p>
        </div>

        <button onClick={() => navigate(role+"/professors")}>Volver</button>
      </div>
    </div>
  );
}

export default ProfessorDetails;
