'use server'

import Image from 'next/image';
import UserProfileClass from 'classes/user-profile';
import LogoutButton from 'components/buttons/logout-button';

const UserProfile: React.FC<UserProfileClass> = ({ id, name, email, urlImage }) => {
  return (
    <div>
      <p>name: {name}</p>
      <p>Email: {email}</p>
      <Image priority={true} width={38} height={38} src={urlImage} alt={"Profile Image"} />
      <LogoutButton></LogoutButton>
    </div>
  );
};

export default UserProfile;