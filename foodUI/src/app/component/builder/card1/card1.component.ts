import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';

import { NgFor } from '@angular/common';
import { ResturantModel } from '../../../models/resturantmodel';


@Component({
  selector: 'app-card1',
  standalone: true,
  imports: [NgFor],
  templateUrl: './card1.component.html',
  styleUrl: './card1.component.css',
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class Card1Component {
   resturants?:ResturantModel []=[
    new ResturantModel('a','a','a','a'),
    new ResturantModel('b','a','a','a'),
    new ResturantModel('c','a','a','a'),
    new ResturantModel('c','a','a','a'),
    new ResturantModel('c','a','a','a'),

   ];
}
