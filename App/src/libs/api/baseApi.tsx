export class BaseApi {
  private baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async get<T>(route: string): Promise<T> {
    const url = `${this.baseUrl}/${route}`;
    const response = await fetch(url);
    const data = await response.json();
    return data;
  }

  async post<T>(route: string, body: any): Promise<T> {
    const url = `${this.baseUrl}/${route}`;
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(body),
    });
    const data = await response.json();
    return data;
  }
}