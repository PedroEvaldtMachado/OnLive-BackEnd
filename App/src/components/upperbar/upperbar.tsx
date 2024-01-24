'use client'

import React from 'react';
import { useSession } from "next-auth/react";
import ImageButton from '@/components/image-button/image-button';
import './style.css';

function UpperBar() {
  let  image: string = useSession().data?.user?.image ?? "";

  return (
    <div className="upper-bar">
      <ImageButton priority={true} onClick={() => {}} imageSrc={image} altText="" />
      <div className="space"></div>
      <ImageButton priority={true} onClick={() => {}} imageSrc={image} altText="" />
    </div>
  );
};

export default UpperBar;