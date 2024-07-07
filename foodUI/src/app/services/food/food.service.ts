import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  private baseUrl="";
  constructor(private http:HttpClient) {}
  
  postData(endpoint:string,data:any){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(`${this.baseUrl}/${endpoint}`,data,httpOptions);
  }
}
