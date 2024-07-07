import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';

import { UserModel } from '../../../models/userModel';
import { HttpClient } from '@angular/common/http';
import { AuthApiService } from '../../../services/auth/auth-api.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink,RouterOutlet,FormsModule,ReactiveFormsModule,NgFor,NgIf],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  registerForm?:any;

  users: UserModel[] = [];


  constructor(private apiService:AuthApiService,private http:HttpClient){}

  ngOnInit(){

 
    this.registerForm= new FormGroup({
      Name: new FormControl(null,[Validators.required]),
      Email: new FormControl(null,[Validators.required,Validators.email]),
      Password: new FormControl(null,[Validators.required,Validators.minLength(8)]),
      PhoneNumber: new FormControl(null,[Validators.required,Validators.pattern('^[0-9]*$'),Validators.minLength(10),Validators.maxLength(10)]),
      Address: new FormControl(null,[Validators.required]),
     
    });
  }


  OnFormSubmitted(){
    if (this.registerForm.valid) {
   const addUser={
    name:this.registerForm.value.Name,
    email:this.registerForm.value.Email,
    password:this.registerForm.value.Password,
    phoneNumber:this.registerForm.value.PhoneNumber,
    address:this.registerForm.value.Address, 
   }
   
   

   this.http.post("https://localhost:7122/api/User/register",addUser)
   .subscribe({
    next:(value)=>{
      console.log(`value==${value}`);
    },
    error:(value)=>{
      console.log(`errrross==`,value);
    }

   });
  
  }
  }
  register(data:any){
    this.apiService.postData('register',data)
    .subscribe({
      next:(response)=>{
        console.log('success',response);
      },
      error:(error)=>{
        console.log("error",error);
      }
    })
  }

  fetchUsers(): void {
    this.apiService.getData().subscribe({
      next: (response) => {
        this.users = response;
        console.log('Users fetched successfully:', this.users);
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      }
    });
  }

 
}
