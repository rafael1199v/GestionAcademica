import React, { useState, useEffect} from "react";
import Button from "../../components/button";
import { Link, useNavigate, useParams } from "react-router-dom";
import { ValidateProfessorUpdateForm } from "../../services/ValidationService";
import { updateProfessor } from "../../services/AdministratorService";
import { getProfessorById } from "../../services/ProfessorService";
import { parse, format } from "date-fns"


function ProfessorUpdateForm() {
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});
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
      Id: id,
      Name: professor.name || "",
      LastName: professor.lastName || "",
      Address: professor.address || "",
      PersonalEmail: professor.personalEmail || "",
      InstitutionalEmail: professor.institutionalEmail || "",
      PhoneNumber: professor.phoneNumber || "",
      BirthDate: professor.birthDate || "",
    });
  }

  useEffect(() => {
    getProfessor(id);
  }, [])

  const handleSubmit = async (e) => {
    e.preventDefault();
    const errors = ValidateProfessorUpdateForm(professorForm);

    if(Object.keys(errors).length !== 0){
      setErrors(errors);
      console.error(errors);
      return;
    }

    try {
      const response = await updateProfessor(professorForm);
      window.alert(response.message);
      setErrors({});
      navigate('/professors');
    }
    catch(error) {
      const response = error.response;
      if (response?.status === 400 && response.data?.errors) {
        window.alert("Campos invalidos");
      }
      else if (response?.status === 400 && typeof response.data === 'string') {
        window.alert(response.data);
      }
      else if (response?.data?.message) {
        window.alert(response.data.message);
      }
      else {
        window.alert("Ocurrió un error inesperado.");
        console.error(error);
      }
    }
    
  };
  return (
    <div className="max-w-md mx-auto mt-28 p-4 space-y-4 bg-white rounded-xl shadow-lg">
      <h2 className="text-lg font-bold text-center">Actualizar</h2>

      <form className="space-y-6" onSubmit={handleSubmit}>
        <div className="flex gap-3">
          <div className="flex flex-col gap-0.5">
            <input
              className="w-full h-12 border border-gray-800 px-3 rounded-lg"
              type="text"
              placeholder="Nombre"
              name="firstName"
              value={professorForm.Name}
              onChange={(e) =>
                setProfessorForm((prevProfessorForm) => ({
                  ...prevProfessorForm,
                  Name: e.target.value,
                }))
              }
            />
            {errors.Name && (
              <p className="text-red-500 text-sm mt-1">{errors.Name}</p>
            )}
          </div>

          <div className="flex flex-col gap-0.5">
            <input
              className="w-full h-12 border border-gray-800 px-3 rounded-lg"
              type="text"
              placeholder="Apellido"
              value={professorForm.LastName}
              onChange={(e) =>
                setProfessorForm((prevProfessorForm) => ({
                  ...prevProfessorForm,
                  LastName: e.target.value,
                }))
              }
            />
            {errors.LastName && (
              <p className="text-red-500 text-sm mt-1">{errors.LastName}</p>
            )}
          </div>
        </div>
        <div className="space-y-4">
          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="email"
            placeholder="Email personal"
            value={professorForm.PersonalEmail}
            onChange={(e) =>
              setProfessorForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                PersonalEmail: e.target.value,
              }))
            }
          />
          {errors.PersonalEmail && (
            <p className="text-red-500 text-sm mt-1">{errors.PersonalEmail}</p>
          )}

          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="email"
            placeholder="Email institucional"
            value={professorForm.InstitutionalEmail}
            onChange={(e) =>
              setProfessorForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                InstitutionalEmail: e.target.value,
              }))
            }
          />
          {errors.InstitutionalEmail && (
            <p className="text-red-500 text-sm mt-1">
              {errors.InstitutionalEmail}
            </p>
          )}

          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="text"
            placeholder="Direccion"
            value={professorForm.Address}
            onChange={(e) =>
              setProfessorForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                Address: e.target.value,
              }))
            }
          />
          {errors.Address && (
            <p className="text-red-500 text-sm mt-1">{errors.Address}</p>
          )}

          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="date"
            value={professorForm.BirthDate}
            onChange={(e) =>
              setProfessorForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                BirthDate: e.target.value,
              }))
            }
          />
          {errors.BirthDate && (
            <p className="text-red-500 text-sm mt-1">{errors.BirthDate}</p>
          )}

          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="tel"
            placeholder="Numero de telefono"
            value={professorForm.PhoneNumber}
            onChange={(e) =>
              setProfessorForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                PhoneNumber: e.target.value,
              }))
            }
            pattern="^\d{8}$"
            title="Please enter a valid 10-digit phone number"
          />
          {errors.PhoneNumber && (
            <p className="text-red-500 text-sm mt-1">{errors.PhoneNumber}</p>
          )}
        </div>
        <div className="text-center">
          <Button label="Submit" type="submit" />
        </div>
        <p className="mt-4 text-sm text-gray-600 text-center">
          <Link
            to="/professors"
            className="text-blue-600 hover:underline font-semibold"
          >
            Volver
          </Link>
        </p>
      </form>
    </div>
  );
}

export default ProfessorUpdateForm;
