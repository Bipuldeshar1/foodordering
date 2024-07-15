import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class FoodService {


  constructor(private http: HttpClient, private cookieService:CookieService) {}

  private token =this.cookieService.get('token') ;

  private baseUrl = "https://localhost:7122/api/Food";

  private httpOptions={
    headers: new HttpHeaders({
  
      'Authorization':`Bearer ${this.token}`
    })};


  postData(endpoint: string, data: any) {
    return this.http.post(`${this.baseUrl}/${endpoint}`, data, this.httpOptions);
  }

  getData(endpoint:string){
    return this.http.get(`${this.baseUrl}/${endpoint}`,this.httpOptions);
  }
  updateData(endpoint:string,data:any){
    return this.http.put(`${this.baseUrl}/${endpoint}`,data,this.httpOptions);
  }
  DeleteData(endpoint:string){
    return this.http.delete(`${this.baseUrl}/${endpoint}`,this.httpOptions);
  }
  getSingle(endpoint:string){
    return this.http.get(`${this.baseUrl}/${endpoint}`,this.httpOptions);
  }
  
}
