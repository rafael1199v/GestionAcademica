import { useContext } from "react"
import { AuthContext } from "../context/AuthContext"

export const useAuthContext = () => {
    const user = useContext(AuthContext);

    if(user === undefined)
        throw new Error("Se necesita usar el proveedor del contexto");

    return user;
}