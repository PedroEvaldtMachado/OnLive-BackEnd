'use server'

import NavBar from 'components/navbar';

function DefaultPage({children, } : Readonly<{ children: React.ReactNode; }>) {
  return (
    <div>
      <NavBar></NavBar>
      {children}
    </div>
  );
}

export default DefaultPage;