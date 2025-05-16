import React, { useState } from "react";
import Button from "../atoms/Button";
import { Link } from "react-router-dom";

const LoginForm = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        
        try {
            const response = await fetch('http://localhost:5024/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    email,
                    password
                })
            });

            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(errorData.message || 'Error al iniciar sesión');
            }

            const data = await response.json();
            // Guardar el token en localStorage
            localStorage.setItem('token', data.token);
            // Redirigir al home
            navigate('/');
            
        } catch (err) {
            setError(err.message);
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
                    <Link to="/" className="text-blue-600 hover:underline font-semibold">
                        Regresar
                    </Link>
                </p>
            </form>
        </div>
    );
};

export default LoginForm;
