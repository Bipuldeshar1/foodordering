import { Component } from '@angular/core';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { AuthApiService } from '../../../services/auth/auth-api.service';
import { CookieService } from 'ngx-cookie-service';


@Component({
  selector: 'app-drawer',
  standalone: true,
  imports: [RouterLink,RouterModule],
  templateUrl: './drawer.component.html',
  styleUrl: './drawer.component.css'
})
export class DrawerComponent {

  constructor(private router:Router,private authService:AuthApiService,private cookieService:CookieService){}

 logout(){
  this.authService.postLogout('logout').subscribe({
    next:(value:any)=>{
      if(value.msg=='User logged out successfully'){
        console.log("success",value);
        this.cookieService.delete('token');
        this.router.navigate(['/mainDBoard/login']); 
      }
     
    },
    error:(error)=>{
      console.log("error",error);
    }
  })
 }

}
