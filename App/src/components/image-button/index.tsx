'use client'

import React from 'react';
import Image from 'next/image';
import './style.css';

interface ImageButtonProps {
  priority?: boolean;
  imageSrc: string;
  altText: string;
  onClick?: () => void | null;
  onMouseOver?: () => void | null;
}

const ImageButton: React.FC<ImageButtonProps> = ({ onClick, onMouseOver, imageSrc, altText, priority = false }) => {
  return (
    <button onClick={onClick} onMouseOver={onMouseOver}>
      {
        imageSrc != null && imageSrc.trim().length > 0
        ? <Image priority={priority} width={38} height={38} src={imageSrc} alt={altText} />
        : <p>{altText}</p>
      }
    </button>
  );
};

export default ImageButton;
