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

  const modalClose = async () => {
    setModalOpen(false);
    await getAvailableVacancies();
  }

  const openModal = () => {
    setModalOpen(true);
  }

  const getAvailableVacancies = async () => {
    try {
        const data = await vacancyService.getAvailableVacancies(userSession.userRoleId);
        setVacancies(data);
    }
    catch(error) {
        alert(error.message);
    }
  }

  useEffect(() => {
    getAvailableVacancies();
  }, []);

  return (
    <>
      <div className="flex flex-col gap-4">
        <h1 className="text-4xl">Vacantes</h1>
        <p className="text-xl">
          En esta página pueden verse las materias con cupos libres para
          postularse. Para ver más detalles de una vacante y postular a ella, 
          haga click en la tarjeta.
        </p>
        <ul className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-3">

          { vacancies.map(vacancy => (
            <ItemVacante
                key={vacancy.id}
                item={vacancy}
                onClick={() => {
                    setSelectedVacancy(vacancy);
                    openModal();
                }}
            />
          ))}
        </ul>
      </div>

      <ApplyModal isOpen={modalOpen} onClose={modalClose} title={selectedVacancy?.name} id={selectedVacancy?.id} applicantId={userSession.userRoleId} />
    </>
  )
}

export default VacanciesListApplicant