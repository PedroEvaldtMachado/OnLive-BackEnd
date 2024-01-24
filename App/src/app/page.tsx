import loginIsRequiredServer from "@/libs/auth/loginIsRequiredServer";

async function SignIn() {
  await loginIsRequiredServer();

  return (
    <div className="flex">
      <h1>Dashboard</h1>
      
    </div>
  );
}

export default SignIn;