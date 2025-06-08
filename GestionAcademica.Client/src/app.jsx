import Layout from "./pages/layout";
import Home from "./pages/home";
import Docentes from "./features/docentes/DocenteTable";
import Reports from "./pages/reports";
import Materias from "./pages/materias";
import DocenteRegisterForm from "./features/docentes/DocenteRegisterForm";
import DocenteUpdateForm from "./features/docentes/DocenteUpdateForm";
import DocenteDetails from "./features/docentes/DocenteDetails";
import LoginForm from "./pages/login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ProtectedRoute from "./components/ProtectedRoute";
import { useAuthContext } from "./hooks/UseAuthContext";


function App() {

  const { userSession } = useAuthContext();

  return (
      <Router>
          <Routes>
            <Route path="/login" element={<LoginForm />} />
            <Route element={<ProtectedRoute canActivate={!!(userSession?.userId)}  redirectPath="/login"/>}>
              <Route element={<Layout />}>
                  <Route path="/" element={<Home />} />
                  <Route path="/docentes" element={<Docentes />} />
                  <Route path="/reportes" element={<Reports />} />
                  <Route path="/registrar-docente" element={<DocenteRegisterForm />} />
                  <Route path="/editar-docente/:id" element={<DocenteUpdateForm />} />
                  <Route path="detalles-docente/:id" element={<DocenteDetails />} />
                  <Route path="/materias" element={<Materias />} />
              </Route>
            </Route>
          </Routes>
      </Router>
  );
}

export default App;
