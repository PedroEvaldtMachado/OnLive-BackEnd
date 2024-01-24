/* eslint-disable react-hooks/rules-of-hooks */
'use client'

import { SIGN_IN } from './config';
import { useSession } from 'next-auth/react';
import { useRouter } from 'next/router';

export default function loginIsRequeredClient() {

  if(typeof window !== "undefined") {
    const session = useSession();
    const router = useRouter();

    if(!session) router.push(SIGN_IN);
  }
}