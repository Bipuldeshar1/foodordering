import { Routes } from '@angular/router';
import { ResturantDetailComponent } from './component/screen/resturant-detail/resturant-detail.component';
import { HomeComponent } from './component/screen/home/home.component';
import { LoginComponent } from './component/auth/login/login.component';
import { RegisterComponent } from './component/auth/register/register.component';
import { DashboardComponent } from './component/screen/dashboard/dashboard.component';

export const routes: Routes = [
    {path:'', component:HomeComponent,},
    {path:'ResturantDetail', component:ResturantDetailComponent,},
    {path:'login', component:LoginComponent,},
    {path:'register', component:RegisterComponent,},  
    {
        path: 'dashboard',
        component: DashboardComponent,
        children: [
            { path: '', redirectTo: 'login', pathMatch: 'full' }, // Default to login when /dashboard is accessed
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            // Add more child routes as needed
        ]
    },

   


];
