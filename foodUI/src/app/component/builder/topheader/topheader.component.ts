import { Component, Input } from '@angular/core';
import { CartService } from '../../../services/cart/cart.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-topheader',
  standalone: true,
  imports: [],
  templateUrl: './topheader.component.html',
  styleUrl: './topheader.component.css'
})
export class TopheaderComponent {
 
  noOfItemCart: number = 0;
  private cartSubscription: Subscription = new Subscription();
  
  constructor(private cartServices:CartService,private router:Router){}

  ngOnInit() {
    this.cartSubscription = this.cartServices.cartItemCount$.subscribe(
      count => {
        this.noOfItemCart = count;
        console.log(this.noOfItemCart); // Debugging statement to check the number of items in the cart
      }
    );
  }
  ngOnDestroy() {
    if (this.cartSubscription) {
      this.cartSubscription.unsubscribe();
    }
  }

  cartnavigate() {
    this.router.navigate(['/cart']);
  }
}
