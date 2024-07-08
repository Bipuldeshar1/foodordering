import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {


  constructor(private http:HttpClient,private cookieService:CookieService) { }

  private token =this.cookieService.get('token') ;
  private baseUrl = "  https://localhost:7122/api/Category";


  getData(endpoint:string){
    const httpOptions={
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.token}`
      })
    };
    return this.http.get(`${this.baseUrl}/${endpoint}`,httpOptions);
  }
  postData(endpoint:string,data:any){
    const httpOptions={
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.token}`
      })
    };

    return this.http.post(`${this.baseUrl}/${endpoint}`,data,httpOptions);
  }
  updateData(endpoint:string,data:any){
    const httpOptions={
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.token}`
      })
    };

    return this.http.put(`${this.baseUrl}/${endpoint}`,data,httpOptions);
  }
  deleteData(endpoint:string,id:any){
    const httpOptions={
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.token}`
      })
    };

    return this.http.delete(`${this.baseUrl}/${endpoint}/${id}`,httpOptions);
  }

}
