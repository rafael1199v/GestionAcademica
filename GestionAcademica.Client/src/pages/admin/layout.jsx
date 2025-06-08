import { Outlet } from "react-router-dom";
import SideBar from "../../components/side-bar";

function Layout({ children }) {
  const { isAuthenticated } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => { 
    if (!isAuthenticated) {
      navigate("/login");
    };
  }, []);

  const isLoginPage = location.pathname === "/login";

  if (isLoginPage) {
    return <div className="flex-1">{children}</div>;
  }

  return (
    <div className="flex min-h-screen">
      <SideBar />
      <div className="flex-1 p-8">
        <Outlet />
      </div>
    </div>
  );
}

export default Layout;
