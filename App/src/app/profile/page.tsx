import React from 'react';
import UserProfile from 'components/user-profile';
import Content from 'components/content';
import DefaultPage from 'components/defaut-page';
import { User, getServerSession } from 'next-auth';
import { getProfileFromUser } from 'libs/user/functions';
import loginIsRequiredServer from 'libs/auth/loginIsRequiredServer';
import SessionProvider from 'libs/providers/session';

export const PROFILE_PAGE_ROUTE = '/profile';

async function Profile() {
  await loginIsRequiredServer(true);
  const user = (await getServerSession())?.user as User;
  const userProf = getProfileFromUser("teste", user);

  return (
    <SessionProvider>
      <DefaultPage>
        <Content>
          <h1>User Profile</h1>
          <UserProfile {...userProf} />
        </Content>
      </DefaultPage>
    </SessionProvider>
  );
};

export default Profile;