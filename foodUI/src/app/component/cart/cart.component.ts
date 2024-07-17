import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { CartModel } from '../../models/cartModel';
import { CartService } from '../../services/cart/cart.service';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [NgFor],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {

   cartItems:CartModel[]=[];

   constructor(private cartService:CartService){}

   ngOnInit() {
    this.cartItems = this.cartService.cart; 
  }

  calculateTotalPrice(){
  let total=0;
  this.cartItems.forEach(i=>{
    total += i.food.price *i.quantity;
  });
  return total;
  }

  quantityIncrease(index:number){
   this.cartItems[index].quantity++;
  }
  quantityDecrease(index:number){
    if(this.cartItems[index].quantity>1){
      this.cartItems[index].quantity--;
    }
  }

  buyNow(){
    while(this.cartItems.length>0){
      this.cartItems.pop();
    }
  }
}
