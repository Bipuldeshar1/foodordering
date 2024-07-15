import { Component } from '@angular/core';
import { ResturantModel } from '../../../models/resturantmodel';
import { NgFor, NgIf } from '@angular/common';
import { Card3Component } from '../../builder/card3/card3.component';
import { Router, RouterLink } from '@angular/router';
import { FoodModel } from '../../../models/foodModel';
import { FoodService } from '../../../services/food/food.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';


@Component({
  selector: 'app-products',
  standalone: true,
  imports: [NgFor,Card3Component,RouterLink,Card3Component,NgIf],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent  {
  food: FoodModel[] = [];
  isModalOpen= false;
  selectedProductId:any;

  constructor(
    private foodService: FoodService,
    private http: HttpClient,
    private cookieService: CookieService,
    private router:Router
  ) {}

  ngOnInit() {
    this.getFood();
  }

  openModal(food:FoodModel){
    this.isModalOpen = true;
    this.selectedProductId=food.id;
  
  }
  closeModal() {
    this.isModalOpen = false;
  
  }


  private token = this.cookieService.get('token');
  private httpOptions = {
    headers: new HttpHeaders({
      'Authorization': `Bearer ${this.token}` // Added space after 'Bearer'
    })
  };

  getFood() {
    this.http.get('https://localhost:7122/api/Food/get', this.httpOptions).subscribe({
      next: (value: any) => {
        console.log('Response:', value);
      this.food = value;
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }

  delete(id:any){
    this.http.delete(`https://localhost:7122/api/Food/delete/${id}`, this.httpOptions).subscribe({
      next: (value: any) => {
        console.log('Response:', value);
        this.closeModal();
      
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }

  updateProduct() {
    if (this.selectedProductId !== null) {
      

      this.router.navigate(['/mainDBoard/update-food'], { queryParams: { id: this.selectedProductId } });
    }
  }

}