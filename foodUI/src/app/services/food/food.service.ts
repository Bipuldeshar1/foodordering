import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FoodService {
  
  private token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySWQiOiI2NGQ4YWQ2Zi0yYjFkLTRlNDQtOGZhOC0xMGQzNDAxYjdkYWUiLCJ1c2VyTmFtZSI6ImFkbWluIiwiZXhwIjoxNzIwMzQ1ODMxLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTIyIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzEyMiJ9.kXWYbVMnXEPoEoUMcI29upcJ34ufr9k0E4-eaAvRM1U";
  private baseUrl = "https://localhost:7122/api/Food";

  constructor(private http: HttpClient) {}

  postData(endpoint: string, data: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.token}`
      })
    };
    return this.http.post(`${this.baseUrl}/${endpoint}`, data, httpOptions);
  }
}
