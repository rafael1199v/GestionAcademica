import React, { useState } from "react";
import SideBarItem from "./SideBarItem";
import { SIDE_BAR_ITEM } from "../config/SideBarItem-const";
import { HomeIcon, ArrowLeftIcon } from "@heroicons/react/16/solid";

export function SideBar() {
  const [selectedItem, setSelectedItem] = useState(SIDE_BAR_ITEM.PROFESSOR);

  return (
    <div className="w-64 h-screen flex-col justify-between border-e border-gray-100 bg-white">
      <div className="px-4 py-6">
        <span className="grid h-10 w-32 place-content-center rounded-lg bg-gray-100 text-xs text-gray-600">
          Gestion Academica
        </span>

        <ul className="mt-6 space-y-1">
          <SideBarItem
            text="General"
            isSelected={selectedItem === SIDE_BAR_ITEM.PROFESSOR}
            onClick={() => setSelectedItem(SIDE_BAR_ITEM.PROFESSOR)}
            icon={<HomeIcon className="w-4 h-4" />}
          />
          <SideBarItem
            text="Cerrar sesion"
            isSelected={selectedItem === SIDE_BAR_ITEM.SIGN_OUT}
            onClick={() => setSelectedItem(SIDE_BAR_ITEM.SIGN_OUT)}
            icon={<ArrowLeftIcon className="w-4 h-4" />}
          />
        </ul>
      </div>
    </div>
  );
}

export default SideBar;
