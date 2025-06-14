import SidebarApplicant from "./SidebarApplicant";
import { Outlet } from "react-router-dom";

function LayoutApplicant() {
  return (
    <div className="flex min-h-screen">
      <SidebarApplicant />
      <div className="flex-1 p-8">
        <Outlet />
      </div>
    </div>
  );
}

export default LayoutApplicant;