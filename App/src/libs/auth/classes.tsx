import { User } from "next-auth";

export class RequestUserAuthentication {
  username?: string | null;
  password?: string | null;

  constructor(username: string, password: string) {
    this.username = username;
    this.password = password;
  }
};

export class ResponseUserAuthentication implements User {
  id: string = "";
  name?: string | null;
  email?: string | null;
  image?: string | null;

  constructor(id: string, name: string, email: string, image: string) {
    this.id = id;
    this.name = name;
    this.email = email;
    this.image = image;
  }
}