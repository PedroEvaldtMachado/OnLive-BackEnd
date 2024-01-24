import { SIGN_IN } from "./config";
import { getServerSession } from "next-auth/next";
import { authConfig } from "./auth";
import { redirect } from "next/navigation";

export default async function loginIsRequiredServer() {
  const session = await getServerSession(authConfig);
  if (!session) redirect(SIGN_IN);
}