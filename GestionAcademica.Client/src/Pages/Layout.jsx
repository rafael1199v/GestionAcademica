import React from 'react'
import SideBar from '../components/SideBar'

function Layout({children}) {
  return (
    <div className='flex flex-row'>
        <SideBar />
        <div className='ml-3'>
          {children}
        </div>
    </div>
  )
}

export default Layout