import { Component } from '@angular/core';
import { ResturantModel } from '../../../models/resturantmodel';
import { NgFor } from '@angular/common';
import { Card3Component } from '../../builder/card3/card3.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [NgFor,Card3Component],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  resturants?:ResturantModel []=[
    new ResturantModel('a','a','a','a'),
    new ResturantModel('b','a','a','a'),
    new ResturantModel('c','a','a','a'),
    new ResturantModel('a','a','a','a'),
    new ResturantModel('b','a','a','a'),
    new ResturantModel('c','a','a','a'),
   ];
}
