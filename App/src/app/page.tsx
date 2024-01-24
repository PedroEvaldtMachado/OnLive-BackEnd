import loginIsRequiredServer from "@/libs/auth/loginIsRequiredServer";
import Home from "@/app/(home)/home";
import SessionProvider from "@/libs/providers/session";

async function SignIn() {
  await loginIsRequiredServer();

  return (
    <SessionProvider>
      <Home/>
    </SessionProvider>
  );
}

export default SignIn;