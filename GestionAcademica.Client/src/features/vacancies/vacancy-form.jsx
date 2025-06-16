import { useEffect, useState } from "react"
import vacancyService from "../../services/VacancyService";
import vacancyFormValidator from "../../services/ValidationForm/VacancyFormValidator";

function VacancyForm() {
 
  const [subjects, setSubjects] = useState([]);
  const [filteredCareers, setFilteredCareers] = useState([]);
  const [apiError, setApiError] = useState(null);
  const [errors, setErrors] = useState(null);
  const [success, setSuccess] = useState(null);
  const [vacancy, setVacancy] = useState({
    name: "",
    description: "",
    startTime: "",
    endTime: "",
    subjectId: "",
    careerId: "",
    userId: localStorage.getItem('userId')
  });

  const getSubjectsWithCareers = async () => {
    try {
        const data = await vacancyService.getSubjectsWithCareers();
        setSubjects(data);

    }
    catch(error){
        console.error(error.message);
    }
  }

  useEffect(() => {
    getSubjectsWithCareers();
  }, []);


  const handleChangeSubject = (subjectId) => {
    if(!subjectId)
        return;

    const newFilteredCareers = subjects.filter(subject => subject.id == subjectId)[0].careers;
    setFilteredCareers(newFilteredCareers);
  }


  const validate = () => {
    const formErrors = vacancyFormValidator.validate(vacancy);
    const hasErrors = Object.keys(formErrors).length !== 0;
    setErrors(hasErrors ? formErrors : null);

    return !hasErrors;
  }

  const handleSubmit = async (e) => {
    e.preventDefault();
    if(!validate())
        return;

    try {
        await vacancyService.postVacancy(vacancy);
        setSuccess("Vacante creada con exito");
        setTimeout(() => {
            setSuccess(null);
        }, 3000);

        setVacancy({
            name: "",
            description: "",
            startTime: "",
            endTime: "",
            subjectId: "",
            careerId: "",
            adminId: localStorage.getItem('userId')
        })
    }
    catch(error) {
        setApiError(error.message);
    }

  }

  


  return (

    <div className='flex flex-col items-center justify-center h-dvh'>
        <h1 className='text-2xl'>Crear Vacante</h1>
        <form className="w-lg mx-auto" onSubmit={handleSubmit}>
            <div className="mb-5">
                <label htmlFor="name" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Nombre</label>
                <input type="text" id="name" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Nombre de la vacante" required 
                    onChange={(e) => setVacancy({...vacancy, name: e.target.value})}
                    value={vacancy.name}
                />
                { errors && (
                    <p className="text-red-500"> {errors.name}</p>
                )}
            </div>
            <div className="mb-5">
                <label htmlFor="description" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Descripcion</label>
                <textarea type="text" id="description" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Descripcion de la vacante" required 
                    onChange={(e) => setVacancy({...vacancy, description: e.target.value})}
                    value={vacancy.description}
                ></textarea>
                
                { errors && (
                    <p className="text-red-500"> {errors.description}</p>
                )}
            </div>
            <div className="mb-5">
                <label htmlFor="startTime" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Fecha de inicio</label>
                <input type="datetime-local" id="startTime" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Fecha" required 
                    onChange={(e) => setVacancy({...vacancy, startTime: e.target.value})}
                    value={vacancy.startTime}
                />

                 { errors && (
                    <p className="text-red-500"> {errors.startTime}</p>
                )}
            </div>
            <div className="mb-5">
                <label htmlFor="endTime" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Fecha de finalizacion</label>
                <input type="datetime-local" id="endTime" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Fecha" required 
                    onChange={(e) => setVacancy({...vacancy, endTime: e.target.value})}
                    value={vacancy.endTime}
                />

                 { errors && (
                    <p className="text-red-500"> {errors.endTime}</p>
                )}
            </div>
            <div className="mb-5">
                <label htmlFor="subject" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Materia</label>
                <select id="subject" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="name@flowbite.com" required 
                    onChange={(e) => {
                        setVacancy({...vacancy, subjectId: e.target.value});
                        handleChangeSubject(e.target.value);
                    }}
                    value={vacancy.subjectId}
                >
                    <option value="">Ninguno</option>
                    { subjects.map(subject => (
                        <option value={subject.id} key={subject.id}>{subject.name}</option>
                    ))}
                </select>

                { errors && (
                    <p className="text-red-500"> {errors.subjectId}</p>
                )}
            </div>

            <div className="mb-5">
                <label htmlFor="career" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Carrera</label>
                <select id="career" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="name@flowbite.com" required 
                    onChange={(e) => setVacancy({...vacancy, careerId: e.target.value})}
                    value={vacancy.careerId}
                >
                    <option value="">Ninguno</option>
                    {filteredCareers.map(career => (
                        <option key={career.id} value={career.id}>{career.name}</option>
                    ))}

                </select>

                { errors && (
                    <p className="text-red-500"> {errors.careerId}</p>
                )}
            </div>

            { success && (
            <div className="p-4 mb-4 text-sm text-green-800 rounded-lg bg-green-50 dark:bg-gray-800 dark:text-green-400" role="alert">
                <span className="font-medium">Operacion exitosa</span> { success }
            </div>
            )}

            { apiError && (
                <div className="p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400" role="alert">
                    <span className="font-medium">Hubo un error</span> {apiError}
                </div>
            )}

            <button type="submit" className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800 block">Submit</button>
        </form>

        
    </div>
  )
}

export default VacancyForm;