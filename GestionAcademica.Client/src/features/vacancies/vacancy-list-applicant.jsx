import React, { useEffect, useState } from 'react'
import ItemVacante from './vacancy-item';
import ApplyModal from './apply-to-vacancy-modal';
import vacancyService from '../../services/VacancyService';
import { useAuthContext } from '../../hooks/UseAuthContext';

function VacanciesListApplicant() {
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedVacancy, setSelectedVacancy] = useState(null);
  const [vacancies, setVacancies] = useState([]);
  const { userSession } = useAuthContext();

  console.log(vacancies);

  const modalClose = () => {
    setModalOpen(false);
  }

  const openModal = () => {
    setModalOpen(true);
  }

  const getAvailableVacancies = async () => {
    try {
        const data = await vacancyService.getAvailableVacancies(userSession.userRoleId);
        //console.log(data);
        setVacancies(data);
    }
    catch(error) {
        alert(error.message);
    }
  }

  useEffect(() => {
    getAvailableVacancies();
  }, []);

  

  // TODO: Verificar el rol del usuario para permitir crear nuevas vacantes

  return (
    <>
      <div className="flex flex-col gap-4">
        <h1 className="text-4xl">Vacantes</h1>
        <p className="text-xl">
          En esta página pueden verse las materias con cupos libres para
          postularse, hacer click en cualquiera debe redirigir a una página de
          formulario de postulacion.
        </p>
        <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">

          { vacancies.map(vacancy => (
            <ItemVacante
                key={vacancy.id}
                title={vacancy.name}
                description={vacancy.description}
                onClick={() => {
                    setSelectedVacancy(vacancy);
                    openModal();
                }}
            />
          ))}
          
        </ul>
      </div>

      <ApplyModal isOpen={modalOpen} onClose={modalClose} title={selectedVacancy?.name}/>
    </>
  )
}

export default VacanciesListApplicant