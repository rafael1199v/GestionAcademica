import React from 'react'
import SideBar from '../components/side-bar'

function Layout({children}) {
  return (
    <div className='flex min-h-screen'>
        <SideBar />
        <div className='flex-1 p-8'>
          {children}
        </div>
    </div>
  )
}

export default Layout