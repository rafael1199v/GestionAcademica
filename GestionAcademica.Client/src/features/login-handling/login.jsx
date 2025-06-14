import React, { useState } from "react";
import Button from "../../components/button";
import { Link } from "react-router-dom";
import { login } from "../../services/AuthService";
import { useNavigate } from "react-router-dom";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { ROLES } from "../../config/role-const";

const LoginForm = () => {
  const { setUsersession } = useAuthContext();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await login({email, password});
      localStorage.setItem('userId', response.userId);
      localStorage.setItem('roleId', response.roleId);
      
      setUsersession({userId: response.userId, roleId: response.roleId});
  
      if(response.roleId == ROLES.APPLICANT)
        navigate("/applicant");
      else if(response.roleId == ROLES.HR)
        navigate("/hr");
      else
        navigate("/");

        
    } catch (err) {
      console.log(err);
    }
  };

  return (
    /* From Uiverse.io by themrsami */
    <div className="max-w-md mx-auto mt-28 p-4 space-y-4 bg-white rounded-xl shadow-lg">
      <h2 className="text-3xl font-bold text-center text-gray-800">Login</h2>
      <form className="space-y-6" onSubmit={handleSubmit}>
        <div className="space-y-4">
          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            placeholder="Email"
            id="email"
            name="email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <input
            className="w-full h-12 border border-gray-800 px-3 rounded-lg"
            placeholder="Password"
            id="password"
            name="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <div className="text-center">
          <Button type="submit" label="Sign in" />
        </div>
        <p className="mt-4 text-sm text-gray-600 text-center">
          No tienes una cuenta? {" "}
          <Link to="/register" className="text-blue-600 hover:underline font-semibold">
            Regístrate
          </Link>
        </p>
      </form>
    </div>
  );
};

export default LoginForm;
