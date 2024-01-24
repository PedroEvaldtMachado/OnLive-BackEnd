import { BaseApi } from "./baseApi";

const Api = new BaseApi(process.env.API_URL as string);

export default Api;