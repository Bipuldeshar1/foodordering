import { Routes } from '@angular/router';
import { ResturantDetailComponent } from './component/screen/resturant-detail/resturant-detail.component';
import { HomeComponent } from './component/screen/home/home.component';
import { LoginComponent } from './component/auth/login/login.component';
import { RegisterComponent } from './component/auth/register/register.component';
import { DashboardComponent } from './component/dashboardComponent/dashboard/dashboard.component';
import { MainDashBoardComponentComponent } from './component/screen/main-dash-board-component/main-dash-board-component.component';
import { OrdersComponent } from './component/dashboardComponent/orders/orders.component';
import { ProductsComponent } from './component/dashboardComponent/products/products.component';
import { ReviewComponent } from './component/dashboardComponent/review/review.component';

export const routes: Routes = [
    {path:'', component:HomeComponent,},
    {path:'ResturantDetail', component:ResturantDetailComponent,},
    {path:'login', component:LoginComponent,},
    {path:'register', component:RegisterComponent,},  
  
  
    {
        path: 'mainDBoard',
        component: MainDashBoardComponentComponent,
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' }, // Default to login when /dashboard is accessed
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            {path:'dashboard', component:DashboardComponent,},  
            {path:'orders', component:OrdersComponent,},  
            {path:'product', component:ProductsComponent,},  
            {path:'reviews', component:ReviewComponent,},  
            // Add more child routes as needed
        ]
    },

   


];
