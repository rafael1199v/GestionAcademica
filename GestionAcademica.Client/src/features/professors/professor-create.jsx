import React, { useState } from "react";
import Button from "../../components/button";
import { Link, useNavigate } from "react-router-dom";
import { ValidateProfessorRegisterForm } from "../../services/ValidationService";
import { createProfessor } from "../../services/AdministratorService";

function ProfessorRegisterForm() {
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});
  const [professorForm, setProfessorForm] = useState({
    Name: "",
    LastName: "",
    Address: "",
    PersonalEmail: "",
    InstitutionalEmail: "",
    Password: "",
    ConfirmPassword: "",
    PhoneNumber: "",
    BirthDate: "",
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    const errors = ValidateProfessorRegisterForm(professorForm);

    if(Object.keys(errors).length !== 0){
      setErrors(errors);
      console.error(errors);
      return;
    }

    try {
      const response = await createProfessor(professorForm);
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
      <h2 className="text-lg font-bold text-center">Registro</h2>

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

        <div className="flex gap-3">
          <div className="flex flex-col gap-0.5">
            <input
              className="w-full h-12 border border-gray-800 px-3 rounded-lg"
              type="password"
              placeholder="Contraseña"
              value={professorForm.Password}
              onChange={(e) =>
                setProfessorForm((prevProfessorForm) => ({
                  ...prevProfessorForm,
                  Password: e.target.value,
                }))
              }
            />
            {errors.Password && (
              <p className="text-red-500 text-sm mt-1">{errors.Password}</p>
            )}
          </div>

          <div className="flex flex-col gap-0.5">
            <input
              className="w-full h-12 border border-gray-800 px-3 rounded-lg"
              type="password"
              placeholder="Confirmar contraseña"
              value={professorForm.ConfirmPassword}
              onChange={(e) =>
                setProfessorForm((prevProfessorForm) => ({
                  ...prevProfessorForm,
                  ConfirmPassword: e.target.value,
                }))
              }
            />
            {errors.ConfirmPassword && (
              <p className="text-red-500 text-sm mt-1">
                {errors.ConfirmPassword}
              </p>
            )}
          </div>
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

export default ProfessorRegisterForm;
