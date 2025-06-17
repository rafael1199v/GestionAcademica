import Layout from "./pages/layout";
import Home from "./pages/home";
import Professors from "./features/professors/professor-list";
import VacanciesAdmin from "./features/vacancies/vacancies-admin";
import Subjects from "./features/subjects/subject-list";
import ProfessorRegisterForm from "./features/professors/professor-create";
import ProfessorUpdateForm from "./features/professors/professor-update";
import ProfessorDetails from "./features/professors/professor-details";
import LoginForm from "./features/login-handling/login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ProtectedRoute from "./components/ProtectedRoute";
import { useAuthContext } from "./hooks/UseAuthContext";
import { ROLES } from "./config/role-const";
import VacanciesList from "./features/vacancies/vacancy-list";
import Applications from "./features/applications/applications";
import SubjectDetails from "./features/subjects/subject-details";
import ApplicationDetail from "./features/applications/application-detail";
import ApplicationDetailsHr from "./features/applications/application-details-hr";
import Register from "./features/login-handling/register";
import ApplicationsHrTable from "./features/applications/applications-hr-table";
import VacancyForm from "./features/vacancies/vacancy-form";
import VacancyUpdateForm from "./features/vacancies/vacancie-update-form";


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
                <Route path="/professors" element={<Professors />} />
                <Route path="/vacancies" element={<VacanciesAdmin />} />
                <Route path="/applications" element={<Applications/>}/>
                <Route path="/create-professor" element={<ProfessorRegisterForm />} />
                <Route path="/update-professor/:id" element={<ProfessorUpdateForm />} />
                <Route path="/professor-details/:id" element={<ProfessorDetails />} />
                <Route path="/subjects" element={<Subjects />} />
                <Route path="/subject-details/:id" element={<SubjectDetails />} />
                <Route path="/vacancies/create" element={<VacancyForm />} />
                <Route path="/vacancies/update/:id" element={<VacancyUpdateForm />} />
              </Route>
            </Route>

            <Route element={ <ProtectedRoute canActivate={!!(userSession?.userId) && !!(userSession?.roleId) && userSession?.roleId == ROLES.APPLICANT} redirectPath="/login" /> }>
              <Route element={<Layout />}>
                <Route path="/applicant" element={<Home />} />
                <Route path="/applicant/professors" element={<Professors />} />
                <Route path="/applicant/professor-details/:id" element={<ProfessorDetails />} />
                <Route path="/applicant/vacancies" element={<VacanciesList />} />
                <Route path="/applicant/applications" element={ <Applications />} />
                <Route path="/applicant/applications/:id" element={ <ApplicationDetail />}/>
              </Route>
            </Route>
              
            <Route element={ <ProtectedRoute canActivate={!!(userSession?.userId) && !!(userSession?.roleId) && userSession?.roleId == ROLES.HR} /> } redirectPath="/login">
              <Route element={ <Layout /> }>
                <Route path="/hr" element={ <Home /> }/>
                <Route path="/hr/professors" element={<Professors />} />
                <Route path="/hr/professor-details/:id" element={<ProfessorDetails />} />
                <Route path="/hr/applications" element={ <Applications /> }/>
                <Route path="/hr/applications/:id" element={ <ApplicationDetailsHr /> }/>
              </Route>
            </Route>
          </Routes>
      </Router>
  );
}

export default App;
