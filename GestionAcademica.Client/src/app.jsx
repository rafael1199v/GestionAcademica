import Layout from "./pages/layout";
import Home from "./pages/home";
import Docentes from "./features/docentes/DocenteTable";
import Reports from "./pages/reports";
import Materias from "./pages/materias";
import DocenteRegisterForm from "./features/docentes/DocenteRegisterForm";
import DocenteUpdateForm from "./features/docentes/DocenteUpdateForm";
import DocenteDetails from "./features/docentes/DocenteDetails";
import LoginForm from "./pages/login";
import { AuthService } from "./services/AuthService";
import { useState, useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./pages/AuthContext";
import Materia from "./pages/materia";

function App() {
  return (
    <AuthProvider>
      <Router>
        <Layout>
          <Routes>
            <Route path="/login" element={<LoginForm />} />
            <Route path="/" element={<Home />} />
            <Route path="/docentes" element={<Docentes />} />
            <Route path="/reportes" element={<Reports />} />
            <Route path="/registrar-docente" element={<DocenteRegisterForm />} />
            <Route path="/editar-docente/:id" element={<DocenteUpdateForm />} />
            <Route path="detalles-docente/:id" element={<DocenteDetails />} />
            <Route path="/materias" element={<Materias />} />
            <Route path="/materia/:id" element={<Materia />} />
          </Routes>
        </Layout>
      </Router>
    </AuthProvider>
  );
}

export default App;
