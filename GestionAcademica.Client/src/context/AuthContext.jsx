import { createContext, useState } from "react"

export const AuthContext = createContext(undefined);

export const AuthContextProvider = ({ children }) => {
    const [userSession, setUsersession] = useState(() => {
        const userId = localStorage.getItem('userId');
        const roleId = localStorage.getItem('roleId');

        if(userId && roleId)
            return { userId, roleId }

        return null;
    });

    return (
        <AuthContext.Provider value={{userSession, setUsersession}}>
            { children }
        </AuthContext.Provider>
    );
}