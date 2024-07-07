import { NgIf } from '@angular/common';
import { Component, Injectable } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';


import { UserModel } from '../../../models/userModel';
import { HttpClientModule } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { min } from 'rxjs';
import { AuthApiService } from '../../../services/auth/auth-api.service';




@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterOutlet,RouterLink,NgIf,ReactiveFormsModule,HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  loginForm?:any;

  
 userData!:{email:string,password:string};;

  constructor(private apiService:AuthApiService,private cookieService:CookieService,private router:Router){}

  ngOnInit(){
 

    this.loginForm= new FormGroup({
      Email:new FormControl(null,[Validators.required ,Validators.email]),
      Password:new FormControl(null,[Validators.required])
    });

  }

  login(data:any){
  
    this.apiService.postData('login',data)
   .subscribe({
    next:(response:any)=>{
  
      if(response.msg=='Success Login'){
        console.log('success',response);
        const token=response.token;
        console.log(token);
        
        this.cookieService.set('token', token);
        this.router.navigate(['/']);
      }
      else{
        console.log(response);
      }

    },
    error:(error)=>{
      console.error('Registration error:', error);
      if (error.status === 400 && error.error && error.error.errors) {
        console.log('Validation errors:', error.error.errors);
        
      } else {
        // Handle other types of errors (e.g., network issues, server errors)
      }
    }
   });
  }

  OnFormSubmitted(){
    if (this.loginForm.valid) {
  
      const addUser={
 
        email:this.loginForm.value.Email,
        password:this.loginForm.value.Password,
 
       }
    this.login(addUser);
      
    } else {
      this.loginForm.markAllAsTouched(); 
    }
  }
}
