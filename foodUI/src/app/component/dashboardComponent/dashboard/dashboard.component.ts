import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { DrawerComponent } from '../../dashboardComponent/drawer/drawer.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [DrawerComponent,RouterOutlet],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(private router: Router){

  }
 
}
