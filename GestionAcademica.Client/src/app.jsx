import { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./Pages/Layout";
import Home from "./pages/home";
import Docentes from "./pages/docentes";
import Reports from "./pages/reports";
import NuevoDocente from "./pages/nuevo-docente";
import Materias from "./pages/materias";
import Vacantes from "./pages/vacantes";
import Postulaciones from "./pages/postulaciones";

function App() {
  return (
    <>
      <Router>
        <Layout>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/docentes" element={<Docentes />} />
            <Route path="/reportes" element={<Reports />} />
            <Route path="/nuevo-docente" element={<NuevoDocente />}/>
            <Route path="/materias" element={<Materias />} />
            {/* <Route path="/vacantes" element={<Vacantes />} />
            <Route path="/postulaciones" element={<Postulaciones />} /> */}
          </Routes>
        </Layout>
      </Router>
    </>
  );
}

export default App;
