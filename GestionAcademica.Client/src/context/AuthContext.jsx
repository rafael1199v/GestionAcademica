import { createContext, useState } from "react"

export const AuthContext = createContext(undefined);

export function AuthContextProvider({ children }){
    const [userSession, setUsersession] = useState(() => {
        const userId = localStorage.getItem('userId');
        const roleId = localStorage.getItem('roleId');
        const userRoleId = localStorage.getItem('userRoleId');

        if(userId && roleId && userRoleId)
            return { userId, roleId, userRoleId }

        return null;
    });

    return (
        <AuthContext.Provider value={{userSession, setUsersession}}>
            { children }
        </AuthContext.Provider>
    );
}