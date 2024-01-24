import { NextAuthOptions, User } from "next-auth";

import CredentialsProvider from "next-auth/providers/credentials";
import GoogleProvider from "next-auth/providers/google";
import Api from "../../api/baseApi";
import { SIGN_IN } from "./config";
import { RequestUserAuthentication, ResponseUserAuthentication } from "./classes";

export const authConfig: NextAuthOptions = {
  providers: [
    CredentialsProvider({
      name: "Login",
      credentials: {
        email: {
          label: "E-mail",
          type: "email",
          placeholder: "example@example.com",
        },
        password: { label: "Senha", type: "password" }
      },
      async authorize(credentials): Promise<User | null> {
          if (!credentials || credentials.email || credentials.password) {
            return null;
          }

          let user = new RequestUserAuthentication(credentials.email, credentials.password);
          let response = await Api.post<ResponseUserAuthentication>(SIGN_IN, user);

          return response;
      }
    }), 
    GoogleProvider({ 
      clientId: process.env.GOOGLE_CLIENT_ID as string,
      clientSecret: process.env.GOOGLE_CLIENT_SECRET as string
    })
  ]
};