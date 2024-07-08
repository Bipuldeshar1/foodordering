import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../../models/userModel';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
  providedIn: 'root'
})
export class AuthApiService {


  constructor(private http:HttpClient,private cookieService:CookieService) { }

  private token=this.cookieService.get('token') ;
  private baseUrl="https://localhost:7122/api/User";
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  getData(){
    return this.http.get<UserModel[]>("https://localhost:7122/api/User/user")
  }

  postData(endpoint: string, data: any) {
    
    return this.http.post(`${this.baseUrl}/${endpoint}`, data,this.httpOptions);
  }

  postLogout(endpoint: string) {
    
    return this.http.post(`${this.baseUrl}/${endpoint}`,this.httpOptions);
  }
  
}
