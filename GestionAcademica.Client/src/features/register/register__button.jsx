import { Link } from "react-router-dom"
import { useNavigate } from "react-router-dom";

function RegisterButton({ goto, text }) {
    return(
        <Link to={goto}>
            <p className={`flex flex-row items-center gap-3 rounded-lg px-4 py-2 text-sm font-medium text-gray-500 hover:bg-gray-100 hover:text-gray-700`}>
                {text}
            </p>
        </Link>
    )
}

export default RegisterButton;