import Layout from "./pages/layout";
import Home from "./pages/home";
import Docentes from "./features/professors/professor-list";
import VacanciesAdmin from "./features/vacancies/vacancies-admin";
import Materias from "./features/subjects/subject-list";
import DocenteRegisterForm from "./features/professors/professor-create";
import DocenteUpdateForm from "./features/professors/professor-update";
import DocenteDetails from "./features/professors/professor-details";
import LoginForm from "./features/login-handling/login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ProtectedRoute from "./components/ProtectedRoute";
import { useAuthContext } from "./hooks/UseAuthContext";
import { ROLES } from "./config/role-const";
import LayoutApplicant from "./features/side-bar/LayoutApplicant";
import VacanciesList from "./features/vacancies/vacancy-list";
import Applications from "./features/applications/applications"; //Why does it give an error on lowercase???
import Materia from "./features/subjects/subject-details";
import ApplicationDetail from "./features/applications/application-detail";
import LayoutHr from "./features/side-bar/LayoutHr";
import ApplicationsHr from "./features/applications/applications-hr";
import ApplicationDetailsHr from "./features/applications/application-details-hr";
import Register from "./features/login-handling/register";


function App() {

  const { userSession } = useAuthContext();

  return (
      <Router>
          <Routes>
            <Route path="/login" element={<LoginForm />} />
            <Route path="/register" element={<Register />} />
            <Route element={<ProtectedRoute canActivate={!!(userSession?.userId) && !!(userSession?.roleId) && userSession?.roleId == ROLES.ADMIN}  redirectPath="/login"/>}>
              <Route element={<Layout />}>
                  <Route path="/" element={<Home />} />
                  <Route path="/docentes" element={<Docentes />} />
                  <Route path="/vacancies" element={<VacanciesAdmin />} />
                  <Route path="/registrar-docente" element={<DocenteRegisterForm />} />
                  <Route path="/editar-docente/:id" element={<DocenteUpdateForm />} />
                  <Route path="/detalles-docente/:id" element={<DocenteDetails />} />
                  <Route path="/materias" element={<Materias />} />
                  <Route path="/materia/:id" element={<Materia />} />
              </Route>
            </Route>

            <Route element={ <ProtectedRoute canActivate={!!(userSession?.userId) && !!(userSession?.roleId) && userSession?.roleId == ROLES.APPLICANT} redirectPath="/login" /> }>
              <Route element={<LayoutApplicant />}>
                  <Route path="/applicant" element={<Home />} />
                  <Route path="/applicant/vacancies" element={<VacanciesList />} />
                  <Route path="/applicant/applications" element={ <Applications />} />
                  <Route path="/applicant/applications/:id" element={ <ApplicationDetail />}/>
              </Route>
            </Route>
              

            <Route element={ <ProtectedRoute canActivate={!!(userSession?.userId) && !!(userSession?.roleId) && userSession?.roleId == ROLES.HR} /> } redirectPath="/login">
              <Route element={ <LayoutHr /> }>
                <Route path="/hr" element={ <Home /> }/>
                <Route path="/hr/applications" element={ <ApplicationsHr /> }/>
                <Route path="/hr/applications/:id" element={ <ApplicationDetailsHr /> }/>
              </Route>
            </Route>
          </Routes>
      </Router>
  );
}

export default App;
