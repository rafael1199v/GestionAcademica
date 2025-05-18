import { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./Pages/Layout";
import Home from "./pages/home";
import Docentes from "./features/docentes/DocenteTable";
import Reports from "./pages/reports";
import Materias from "./pages/materias";
import DocenteRegisterForm from "./features/docentes/DocenteRegisterForm";
import DocenteUpdateForm from "./features/docentes/DocenteUpdateForm";
import DocenteDetails from "./features/docentes/DocenteDetails";
import LoginForm from "./pages/login";
import { AuthService } from "./services/AuthService";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/login" element={<LoginForm />} />
        </Routes>

        {AuthService.isLogIn() && (
          <Layout>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/docentes" element={<Docentes />} />
              <Route path="/reportes" element={<Reports />} />
              <Route path="/registrar-docente" element={<DocenteRegisterForm />} />
              <Route path="/editar-docente/:id" element={<DocenteUpdateForm />} />
              <Route path="detalles-docente/:id" element={<DocenteDetails />} />
              <Route path="/materias" element={<Materias />} />
            </Routes>
          </Layout>
        )}
      </Router>
    </>
  );
}

export default App;
