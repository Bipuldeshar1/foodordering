import { Component } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { Router } from 'express';

@Component({
  selector: 'app-drawer',
  standalone: true,
  imports: [RouterLink,RouterModule],
  templateUrl: './drawer.component.html',
  styleUrl: './drawer.component.css'
})
export class DrawerComponent {

}
