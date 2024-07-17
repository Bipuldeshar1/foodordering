import { Injectable } from '@angular/core';
import { CartModel } from '../../models/cartModel';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }
  
  cart:CartModel[]=[];

  private cartItemCount = new BehaviorSubject<number>(0); 
  cartItemCount$ = this.cartItemCount.asObservable(); 
  
  addToCart(data: CartModel) {
    if (data) {
      const existingItem = this.cart.find(item => item.food.id === data.food.id);
      if (existingItem) {
        alert("Item already in cart");
      } else {
        this.cart.push(data);
        this.updateCartItemCount();
      }
    }
  }
  
  private updateCartItemCount() {
    this.cartItemCount.next(this.cart.length); // Update the BehaviorSubject with the current cart length
    console.log(this.cart.length); // Debugging statement to check the cart length
  }

  getCartItemCount(): number {
    return this.cart.length;
  }

}
