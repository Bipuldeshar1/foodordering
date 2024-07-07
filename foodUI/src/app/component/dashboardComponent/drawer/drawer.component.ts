import { Component } from '@angular/core';
import { Router, RouterLink, RouterModule } from '@angular/router';


@Component({
  selector: 'app-drawer',
  standalone: true,
  imports: [RouterLink,RouterModule],
  templateUrl: './drawer.component.html',
  styleUrl: './drawer.component.css'
})
export class DrawerComponent {

  constructor(private router:Router){}

 
}
