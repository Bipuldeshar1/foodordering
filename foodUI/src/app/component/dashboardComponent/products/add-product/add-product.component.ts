import { Component, Injectable } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FoodService } from '../../../../services/food/food.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
@Component({
  selector: 'app-add-product',
  imports:[ReactiveFormsModule,RouterModule],
  standalone:true,
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],

})
export class AddProductComponent {

  addProductForm: any;
  img: any;
  outOfStock: boolean = false;

  constructor(private foodService: FoodService, private http: HttpClient, private cookieService: CookieService) {}

  ngOnInit() {
    this.addProductForm = new FormGroup({
      name: new FormControl(null),
      description: new FormControl(null),
      address: new FormControl(null),
      quantity: new FormControl(null),
      price: new FormControl(null),
      category: new FormControl(null),
      image: new FormControl(null),
      outOfStock: new FormControl(this.outOfStock)
    });
  }

  onFileSelected(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.img = reader.result; // Set img to base64 data URI
      };
    }
  }

  OnFormSubmitted() {
 const product={
  name:this.addProductForm.value.name,
  description:this.addProductForm.value.description,
  address:this.addProductForm.value.address,
  quantity:this.addProductForm.value.quantity,
  price:this.addProductForm.value.price,
  categoryId:this.addProductForm.value.category,
  imageUrl:this.addProductForm.value.image,
  outOfStock:this.addProductForm.value.outOfStock,
  
 }

 this.foodService.postData('add',product).subscribe({
  next: (value) => {
    console.log(`Response:`, value);
  },
  error: (error) => {
    console.error(`Error:`, error);
  }
  })
}
 
}