import { useContext } from "react"
import { AuthContext } from "../context/AuthContext"

export function useAuthContext () {
    const context = useContext(AuthContext);

    if(context === undefined)
        throw new Error("Se necesita usar el proveedor del contexto");

    return context;
}