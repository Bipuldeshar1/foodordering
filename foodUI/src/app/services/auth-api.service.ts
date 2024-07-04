import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  private baseUrl="https://localhost:7122/api/User";

  constructor(private http:HttpClient) { }

  getData(){
    return this.http.get<UserModel[]>("https://localhost:7122/api/User/user")
  }

  postData(endpoint: string, data: any) {
    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(`${this.baseUrl}/${endpoint}`, data, httpOptions);
  }
  
}
