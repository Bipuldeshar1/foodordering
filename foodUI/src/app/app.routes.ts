import { Routes } from '@angular/router';
import { ResturantDetailComponent } from './component/screen/resturant-detail/resturant-detail.component';
import { HomeComponent } from './component/screen/home/home.component';
import { LoginComponent } from './component/auth/login/login.component';
import { RegisterComponent } from './component/auth/register/register.component';

export const routes: Routes = [
    {path:'', component:HomeComponent,},
    {path:'ResturantDetail', component:ResturantDetailComponent,},
    {path:'login', component:LoginComponent,},
    {path:'register', component:RegisterComponent,},
];
