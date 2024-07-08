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
  file:any;
  
  constructor(private foodService: FoodService, ) {}

  ngOnInit() {
    this.addProductForm = new FormGroup({
      name: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
      address: new FormControl(null, Validators.required),
      quantity: new FormControl(null, Validators.required),
      price: new FormControl(null, Validators.required),
      category: new FormControl(null, Validators.required),
      outOfStock: new FormControl(this.outOfStock)
    });
  }



  onFileSelected(event: any): void {

    this.file=event.target.files[0];
    this.img=event.target.files[0];
  }

  OnFormSubmitted() {
 
    if(!this.file){
      console.log('emoty file')
    } 
    const formData = new FormData();
    formData.append('name', this.addProductForm.value.name);
    formData.append('description', this.addProductForm.value.description);
    formData.append('address', this.addProductForm.value.address);
    formData.append('quantity', this.addProductForm.value.quantity);
    formData.append('price', this.addProductForm.value.price);
    formData.append('categoryName', this.addProductForm.value.category);
    formData.append('imageUrl', this.file);
    formData.append('outOfStock', this.addProductForm.value.outOfStock.toString());



 this.foodService.postData('add',formData).subscribe({
  next: (value) => {
    console.log(`Response:`, value);
  },
  error: (error) => {
    console.error(`Error:`, error);
  }
  })
}

 
}