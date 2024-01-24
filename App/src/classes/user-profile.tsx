export default class UserProfileClass {
  id: string;
  name: string;
  email: string;
  urlImage: string;

  constructor(id: string, name: string, email: string, urlImage: string) {
    this.id = id;
    this.name = name ?? "";
    this.email = email;
    this.urlImage = urlImage;
  };
}