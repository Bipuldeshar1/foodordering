import { CUSTOM_ELEMENTS_SCHEMA, Component, Input } from '@angular/core';

import { NgFor } from '@angular/common';
import { ResturantModel } from '../../../models/resturantmodel';
import { FoodModel } from '../../../models/foodModel';
import { CartService } from '../../../services/cart/cart.service';
import { CartModel } from '../../../models/cartModel';

@Component({
  selector: 'app-card3',
  standalone: true,
  imports: [NgFor],
  templateUrl: './card3.component.html',
  styleUrl: './card3.component.css',
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class Card3Component {
 @Input() food?:FoodModel;

 constructor(private cartService:CartService){}

 addTOCart(data:any){
  const cartItem: CartModel = {
    food: data,
    quantity:1
    
  };
  this.cartService.addToCart(cartItem);
 }
}
