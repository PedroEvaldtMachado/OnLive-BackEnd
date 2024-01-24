'use client'

import React from 'react';
import { useSession } from 'next-auth/react';
import ImageButton from 'components/image-button';
import UserButton from 'components/user-button';
import './style.css';

function NavBar() {
  let  image: string = useSession().data?.user?.image ?? "";

  return (
    <div className="upper-bar">
      <ImageButton priority={true} onClick={() => {}} imageSrc={image} altText="" />
      <div className="space"></div>
      <UserButton />
    </div>
  );
};

export default NavBar;