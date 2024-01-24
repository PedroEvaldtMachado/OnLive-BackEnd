import Home from '@/app/(home)/page';
import SessionProvider from 'libs/providers/session';

async function SignIn() {

  return (
    <SessionProvider>
      <Home/>
    </SessionProvider>
  );
}

export default SignIn;
