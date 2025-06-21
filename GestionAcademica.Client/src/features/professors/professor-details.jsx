import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { getProfessorById } from "../../services/AdministratorService";
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
    <div className="flex flex-col items-center justify-center">
    <div className="flex flex-col w-2xl items-center justify-self-center">
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

        <Button label="Volver" onClick={() => navigate(role+"/professors")}/>
      </div>
    </div>
    </div>
  );
}

export default ProfessorDetails;
