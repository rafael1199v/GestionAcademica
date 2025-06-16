class VacancyFormValidator {
    validate(vacancyForm){
        const errors = {};

        if(!vacancyForm.name.trim())
            errors.name = "El nombre de la vacante es requerido";

        if(!vacancyForm.description.trim())
            errors.description = "Una descripcion es requerida";

        if(!vacancyForm.subjectId.trim())
            errors.subjectId = "Se necesita una materia para crear la vacante";

        if(!vacancyForm.careerId.trim())
            errors.careerId = "Se necesita una carrera seleccionada para crear la vacante";

        
        let startTime = null;
        let endTime = null;

        if(!vacancyForm.startTime.trim()){
            errors.startTime = "Fecha de inicio invalida";
        }
        else {
            startTime = new Date(vacancyForm.startTime);
        }

        if(!vacancyForm.endTime.trim()){
            errors.endTime = "Fecha de finalizacion invalida";
        }
        else {
            endTime = new Date(vacancyForm.endTime);
        }


        if(startTime && endTime){
            if(startTime.getTime() >= endTime.getTime()){
                errors.startTime = "La fecha de inicio no puede ser mayor o igual a la fecha de finalizacion";
            }
            else if(endTime.getTime() < Date.now()){
                errors.endTime = "La fecha de finalizacion no puede ser una pasada";
            }
        }
            
    
        return errors;
    }
}

const vacancyFormValidator = new VacancyFormValidator();
export default vacancyFormValidator;