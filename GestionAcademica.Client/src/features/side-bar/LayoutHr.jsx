import SidebarHr from "./SidebarHr"
import { Outlet } from "react-router-dom"

function LayoutHr() {
  return (
     <div className="flex min-h-screen">
      <SidebarHr />
      <div className="flex-1 p-8">
        <Outlet />
      </div>
    </div>
  )
}

export default LayoutHr