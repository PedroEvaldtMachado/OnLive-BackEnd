'use client'

import { signOut } from 'next-auth/react';

const LogoutButton = () => {
  const signOutAction = () => {
    signOut();
  };

  return (
    <button onClick={signOutAction}>
      Log out
    </button>
  );
};

export default LogoutButton;