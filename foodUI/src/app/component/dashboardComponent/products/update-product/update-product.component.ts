import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { FoodModel } from '../../../../models/foodModel';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FoodService } from '../../../../services/food/food.service';


@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css'],
  standalone:true,
  imports:[ReactiveFormsModule]
})
export class UpdateProductComponent {
  food?: FoodModel;
  UpdateProductForm: any;
  id?: string;
  img:any;
  
  constructor(
    private http: HttpClient,
    private cookieService: CookieService,
    private route: ActivatedRoute,
    private foodService:FoodService,
    private router:Router
  ) {
 
  
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      this.getById(this.id);
    });

    this.UpdateProductForm = new FormGroup({
      id: new FormControl(null, Validators.required),
      name: new FormControl(null, Validators.required),
      description: new FormControl(null, Validators.required),
      address: new FormControl(null, Validators.required),
      quantity: new FormControl(null, Validators.required),
      price: new FormControl(null, Validators.required),
      category: new FormControl(null, Validators.required),
      imageUrl: new FormControl(null, Validators.required),
      outOfStock: new FormControl(null,Validators.required),
    });
  }

  private token = this.cookieService.get('token');
  private httpOptions = {
    headers: new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    })
  };

  getById(id: any) {
    this.http.get<FoodModel>(`https://localhost:7122/api/Food/getById/${id}`, this.httpOptions)
      .subscribe({
        next: (value: any) => {
        console.log(value);
        
          this.food = value.food;
          console.log("food",this.food);
          this.img=value.food.imageUrl;
          this.patchFormValues();
          

        },
        error: (error) => {
          console.error('Error:', error);
        }
      });
  }


  patchFormValues() {
    this.UpdateProductForm.patchValue({
      id: this.food?.id,
      name: this.food?.name,
      description: this.food?.description,
      address: this.food?.address,
      quantity: this.food?.quantity,
      price: this.food?.price,
      category: this.food?.category?.categoryName,
      imageUrl: this.food?.imageUrl,
      outOfStock: this.food?.outOfStock.toString(),
    });
  }
  // Handle file selected event
  onFileSelected(event: any) {

   this.img=event.target.files[0];
  }

  // Handle form submission
  OnFormSubmitted() {

  const formData = new FormData();
  formData.append('id', this.UpdateProductForm.value.id);
  formData.append('name', this.UpdateProductForm.value.name);
  formData.append('description', this.UpdateProductForm.value.description);
  formData.append('address', this.UpdateProductForm.value.address);
  formData.append('quantity', this.UpdateProductForm.value.quantity);
  formData.append('price', this.UpdateProductForm.value.price);
  formData.append('category', this.UpdateProductForm.value.category);
  formData.append('imageUrl', this.img??this.UpdateProductForm.value.imageUrl);
  formData.append('outOfStock', this.UpdateProductForm.value.outOfStock.toString());
  
   this.foodService.updateData('update',formData)
   .subscribe({
    next: (value: any) => {
      console.log('Response:', value);
    this.router.navigate(['mainDBoard/product'])
    },
    error: (error) => {
      console.error('Error:', error);
    }
   })
  }
}
