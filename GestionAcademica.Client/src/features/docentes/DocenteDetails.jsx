import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect} from "react";
import { updateProfessor, getProfessorById } from "../../services/AdministratorService";

function DocenteDetails() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [professorForm, setProfessorForm] = useState({
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
    const professor = await getProfessorById(id);
    setProfessorForm({
      Name: professor.Name || "",
      LastName: professor.LastName || "",
      Address: professor.Address || "",
      PersonalEmail: professor.PersonalEmail || "",
      InstitutionalEmail: professor.InstitutionalEmail || "",
      PhoneNumber: professor.PhoneNumber || "",
      BirthDate: professor.BirthDate || "",
    });
  };
  useEffect(() => {
      getProfessor(id);
    }, [])

  return (
    <div>
      <h1 class="text-xl">Detalles del Docente</h1>
      <p>Información detallada del docente seleccionado.</p>
      <div class="mb-9"></div>
      <div class="flex flex-col mb-4">
        <div class="flex flex-row mb-2">
          <label>Nombre Completo:</label>
          <p>{professorForm.Name} {professorForm.LastName}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Dirección:</label>
          <p>{professorForm.Address}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Email Personal:</label>
          <p>{professorForm.PersonalEmail}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Email Institucional:</label>
          <p>{professorForm.InstitutionalEmail}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Teléfono:</label>
          <p>{professorForm.PhoneNumber}</p>
        </div>
        <div class="flex flex-row mb-2">
          <label>Fecha de Nacimiento:</label>
          <p>{professorForm.BirthDate}</p>
        </div>

        <button onClick={() => navigate('/docentes')}>Volver</button>
      </div>
    </div>
  );
}

export default DocenteDetails;
