import { Component } from '@angular/core';
import { ResturantModel } from '../../../models/resturantmodel';
import { NgFor } from '@angular/common';
import { Card3Component } from '../../builder/card3/card3.component';
import { RouterLink } from '@angular/router';
import { FoodModel } from '../../../models/foodModel';
import { FoodService } from '../../../services/food/food.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [NgFor,Card3Component,RouterLink,Card3Component],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent  {
  food: FoodModel[] = [];

  constructor(
    private foodService: FoodService,
    private http: HttpClient,
    private cookieService: CookieService
  ) {}

  ngOnInit() {
    this.getFood();
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
}