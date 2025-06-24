import { useParams, Link } from "react-router-dom";
import React, { useState, useEffect } from "react";
import {
  getSubjectById,
  updateSubject,
} from "../../services/AdministratorService";
import { getAllProfessors } from "../../services/ProfessorService";

function SubjectDetails() {
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
    <div className="max-w-2xl mx-auto mt-10 bg-white rounded-lg p-8">
      <h1 className="text-3xl font-bold text-gray-800 mb-4">
        Materia: <span className="text-blue-700">{subjectForm.Name}</span>
      </h1>
      <span className="font-semibold mb-6">Descripción:</span>
      <p className="text-gray-700 mb-6">
        {subjectForm.Description}
      </p>
      <p className="mb-6">
        <span className="font-semibold mb-6">Créditos académicos: </span>
        {subjectForm.Credits}
      </p>

      <div className="mb-8">
        <label
          htmlFor="professor"
          className="block font-medium mb-2"
        >
          Profesor asignado:
        </label>
        <select
          className="w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
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

      <p className="text-sm text-gray-500">
        Usa la tabla desplegable para actualizar el docente, el proceso puede tardar unos segundos.
      </p>
      <Link
        to="/subjects"
        className="text-blue-600 hover:underline font-semibold text-center block mt-6"
      >
        Volver
      </Link>
    </div>
  );
}

export default SubjectDetails;
