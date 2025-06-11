import React, { useState } from "react";
import Button from "../components/button";
import { Link, useNavigate } from "react-router-dom";
import { ValidateNewUserRegisterForm } from "../services/ValidationService";
import { createApplicant } from "../services/AuthService";

function Register() {
  const navigate = useNavigate();
  const [errors, setErrors] = useState({});
  const [userForm, setUserForm] = useState({
    Name: "",
    LastName: "",
    Address: "",
    Email: "",
    Password: "",
    ConfirmPassword: "",
    PhoneNumber: "",
    BirthDate: "",
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    const errors = ValidateNewUserRegisterForm(userForm);

    if(Object.keys(errors).length !== 0){
      setErrors(errors);
      console.error(errors);
      return;
    }

    try {
      const response = await createApplicant(userForm);
      setErrors({});
      navigate('/login');
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
              value={userForm.Name}
              onChange={(e) =>
                setUserForm((prevProfessorForm) => ({
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
              value={userForm.LastName}
              onChange={(e) =>
                setUserForm((prevProfessorForm) => ({
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
            value={userForm.Email}
            onChange={(e) =>
              setUserForm((prevProfessorForm) => ({
                ...prevProfessorForm,
                Email: e.target.value,
              }))
            }
          />
          {errors.Email && (
            <p className="text-red-500 text-sm mt-1">{errors.Email}</p>
          )}

          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            type="text"
            placeholder="Direccion"
            value={userForm.Address}
            onChange={(e) =>
              setUserForm((prevProfessorForm) => ({
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
            value={userForm.BirthDate}
            onChange={(e) =>
              setUserForm((prevProfessorForm) => ({
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
            value={userForm.PhoneNumber}
            onChange={(e) =>
              setUserForm((prevProfessorForm) => ({
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
              value={userForm.Password}
              onChange={(e) =>
                setUserForm((prevProfessorForm) => ({
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
              value={userForm.ConfirmPassword}
              onChange={(e) =>
                setUserForm((prevProfessorForm) => ({
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
            Ya tienes una cuenta?{" "}
          <Link
            to="/login"
            className="text-blue-600 hover:underline font-semibold"
          >
            Inicia sesión
          </Link>
        </p>
      </form>
    </div>
  );
}

export default Register;
