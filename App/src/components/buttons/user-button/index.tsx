'use client'

import { PROFILE_PAGE_ROUTE } from 'app/profile/page';
import { getImageFromUseSession as getImageUrlFromUseSession } from 'libs/user/functions';
import ImageButton from '@/components/buttons/image-button';
import { useSession } from 'next-auth/react';
import { useRouter } from 'next/navigation';

const UserButton = () => {
  const router = useRouter();
  const session = useSession();
  let imageUrl: string = getImageUrlFromUseSession(session) ?? "";

  const redirectToProfile = () => {
    router.push(PROFILE_PAGE_ROUTE);
  }

  return (
    <ImageButton imageSrc={imageUrl} altText='Profile Image' priority={true} onClick={redirectToProfile}></ImageButton>
  )
}

export default UserButton;