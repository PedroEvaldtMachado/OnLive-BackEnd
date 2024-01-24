import UserProfileClass from 'classes/user-profile';
import { User } from 'next-auth';
import { SessionContextValue } from 'next-auth/react';

export const getProfileFromUser = (id: string, user?: User) : UserProfileClass => {
  if (!(id?.length > 0) || user == null) {
    return {} as UserProfileClass;
  }

  return new UserProfileClass(id ?? "", user.name ?? "", user.email ?? "", user.image ?? "");
}

export const getImageFromUseSession = (sessionContextValue: SessionContextValue) : string => {
  return sessionContextValue?.data?.user?.image ?? "";
}
