import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { DrawerComponent } from '../../dashboardComponent/drawer/drawer.component';

@Component({
  selector: 'app-main-dash-board-component',
  standalone: true,
  imports: [RouterOutlet,DrawerComponent],
  templateUrl: './main-dash-board-component.component.html',
  styleUrl: './main-dash-board-component.component.css'
})
export class MainDashBoardComponentComponent {
  constructor(private router: Router){

  }
 
}
