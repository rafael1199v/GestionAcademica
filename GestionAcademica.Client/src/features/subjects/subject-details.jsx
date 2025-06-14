import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect } from "react";
import {
  getSubjectById,
  getAllProfessors,
  updateSubject,
} from "../../services/AdministratorService";

function Materia() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [professors, setProfessors] = useState([]);
  const [subjectForm, setSubjectForm] = useState({
    Id: id,
    Name: "",
    Description: "",
    Credits: "",
    ProfessorId: "",
    ProfessorName: "",
  });

  const getSubject = async (id) => {
    const subject = await getSubjectById(id);
    setSubjectForm({
      Id: subject.id,
      Name: subject.name || "",
      Description: subject.description || "",
      Credits: subject.credits || "",
      ProfessorId: subject.professorId || "",
      ProfessorName: subject.professorName || "",
    });
  };

  const loadProfessors = async () => {
    const professorsList = await getAllProfessors();
    setProfessors(professorsList);
  };

  const handleProfessorChange = async (e) => {
    const selectedProfessorId = parseInt(e.target.value);
    const selectedProfessor = professors.find(
      (p) => p.id === selectedProfessorId
    );

    const updatedSubject = {
      ...subjectForm,
      ProfessorId: selectedProfessorId,
      ProfessorName: selectedProfessor ? selectedProfessor.fullName : "",
    };

    try {
      await updateSubject(updatedSubject);
      setSubjectForm(updatedSubject);
    } catch (error) {
      console.error("Error al actualizar el profesor:", error);
    }
  };

  useEffect(() => {
    getSubject(id);
    loadProfessors();
  }, []);

  return (
    <div className="container mt-4">
      <h1>Materia: {subjectForm.Name}</h1>
      <p>Descripcion:<br></br>{subjectForm.Description}</p>

      <div className="form-group mt-4">
        <label htmlFor="professor">Profesor asignado:</label>
        <select
          className="form-control"
          id="professor"
          value={subjectForm.ProfessorId}
          onChange={handleProfessorChange}
        >
          <option value="">Seleccione un profesor</option>
          {professors.map((professor) => (
            <option key={professor.id} value={professor.id}>
              {professor.fullName}
            </option>
          ))}
        </select>
      </div>

      <p className="mt-2">
        <br></br>
        <br></br>
        Usa la tabla desplegable para actualizar el docente, el proceso puede tardar unos segundos
      </p>
    </div>
  );
}

export default Materia;
