export const ValidateProfessorRegisterForm = (professorForm) => {
    const errors = {};
    const phoneRegex = /^\d{8}$/;

    if(!professorForm.Name.trim()) {
        errors.Name = "El nombre es requerido.";
    }

    if(!professorForm.LastName.trim()) {
        errors.LastName = "El apellido es requerido.";
    }

    if(!professorForm.PersonalEmail.trim()) {
        errors.PersonalEmail = "El correo personal es requerido.";
    }

    if(!professorForm.InstitutionalEmail.trim()) {
        errors.InstitutionalEmail = "El correo de la universidad es requerido.";
    }

    if(!professorForm.Address.trim()) {
        errors.Address = "La direccion es requerida.";
    }

    if(!professorForm.Password) {
        errors.Password = "La contraseña es requerida.";
    }

    if(!professorForm.ConfirmPassword) {
        errors.ConfirmPassword = "La confirmación de contraseña es requerida.";
    }
    else if(professorForm.Password !== professorForm.ConfirmPassword) {
        errors.ConfirmPassword = "Las contraseñas no coinciden.";
    }

    if(!professorForm.PhoneNumber) {
        errors.PhoneNumber = "El teléfono es requerido.";
    }
    else if(!phoneRegex.test(professorForm.PhoneNumber)) {
        errors.PhoneNumber = "El teléfono debe tener 8 dígitos.";
    }

    if(!professorForm.BirthDate) {
        errors.BirthDate = "La fecha de nacimiento es requerida.";
    }
    
    return errors;
}


export const ValidateProfessorUpdateForm = (professorForm) => {
    const errors = {};
    const phoneRegex = /^\d{8}$/;

    if(!professorForm.Name.trim()) {
        errors.Name = "El nombre es requerido.";
    }

    if(!professorForm.LastName.trim()) {
        errors.LastName = "El apellido es requerido.";
    }

    if(!professorForm.PersonalEmail.trim()) {
        errors.PersonalEmail = "El correo personal es requerido.";
    }

    if(!professorForm.InstitutionalEmail.trim()) {
        errors.InstitutionalEmail = "El correo de la universidad es requerido.";
    }

    if(!professorForm.Address.trim()) {
        errors.Address = "La direccion es requerida.";
    }

    if(!professorForm.PhoneNumber) {
        errors.PhoneNumber = "El teléfono es requerido.";
    }
    else if(!phoneRegex.test(professorForm.PhoneNumber)) {
        errors.PhoneNumber = "El teléfono debe tener 8 dígitos.";
    }

    if(!professorForm.BirthDate) {
        errors.BirthDate = "La fecha de nacimiento es requerida.";
    }
    
    return errors;
}

export const ValidateNewUserRegisterForm = (userForm) => {
    const errors = {};
    const phoneRegex = /^\d{8}$/;

    if(!userForm.Name.trim()) {
        errors.Name = "El nombre es requerido.";
    }

    if(!userForm.LastName.trim()) {
        errors.LastName = "El apellido es requerido.";
    }

    if(!userForm.Email.trim()) {
        errors.Email = "El correo es requerido.";
    }

    if(!userForm.Address.trim()) {
        errors.Address = "La direccion es requerida.";
    }

    if(!userForm.Password) {
        errors.Password = "La contraseña es requerida.";
    }

    if(!userForm.ConfirmPassword) {
        errors.ConfirmPassword = "La confirmación de contraseña es requerida.";
    }
    else if(userForm.Password !== userForm.ConfirmPassword) {
        errors.ConfirmPassword = "Las contraseñas no coinciden.";
    }

    if(!userForm.PhoneNumber) {
        errors.PhoneNumber = "El teléfono es requerido.";
    }
    else if(!phoneRegex.test(userForm.PhoneNumber)) {
        errors.PhoneNumber = "El teléfono debe tener 8 dígitos.";
    }

    if(!userForm.BirthDate) {
        errors.BirthDate = "La fecha de nacimiento es requerida.";
    }
    
    return errors;
}