import { Component } from '@angular/core';
import { ResturantModel } from '../../../models/resturantmodel';
import { NgFor } from '@angular/common';
import { Card3Component } from '../../builder/card3/card3.component';
import { RouterLink } from '@angular/router';
import { FoodModel } from '../../../models/foodModel';
import { FoodService } from '../../../services/food/food.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [NgFor,Card3Component,RouterLink],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
 food:FoodModel[]=[];

   constructor(private foodService:FoodService){} 
   
  ngonInit(){
    
  }
  
  getFood(){
    this.foodService.getData('get').subscribe({
      next: (value) => {
        console.log(`Response:`, value);
      },
      error: (error) => {
        console.error(`Error:`, error);
      }
    })
  }
}
