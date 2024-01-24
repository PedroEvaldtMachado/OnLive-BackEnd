import { SIGN_IN } from './config';
import { getServerSession } from 'next-auth/next';
import { authConfig } from './auth';
import { redirect } from 'next/navigation';
import delay from 'libs/delay';

export default async function loginIsRequiredServer(withLoop: boolean) {
  const session = await getServerSession(authConfig);
  if (!session) redirect(SIGN_IN);
  loginIsRequiredServerLoop();
}

export async function loginIsRequiredServerLoop() {
  while(true) {
    await delay(60000);
    await loginIsRequiredServer(false);
  }
};