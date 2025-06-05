import { Link, useNavigate, useParams } from "react-router-dom";
import React, { useState, useEffect} from "react";
import { getSubjectById } from "../services/AdministratorService";

function Materia() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [subjectForm, setSubjectForm] = useState({
            Id: id,
            Name: '',
            Description: '',
            Professor: ''
  });
  const getSubject = async (id) => {
    const subject = await getSubjectById(id);
    setSubjectForm({
      Name: subject.Name || "",
      Description: subject.Description || "",
      Professor: subject.Professor || "",
    });
  };
  useEffect(() => {
    getSubject(id);
  }, []);
  return (
    <div>
      <h1>Materia: {subjectForm.Name}</h1>
      <p>{subjectForm.Description}</p>
      <p>Qué mas añado? xddddddd</p>
      <div className="p-5"></div>
      <p>
        Aquí debe haber un input para actualizar el docente que enseña la
        materia.
      </p>
      <p>{subjectForm.Professor}</p>
      {/* <input/> */}
    </div>
  );
}

export default Materia;
