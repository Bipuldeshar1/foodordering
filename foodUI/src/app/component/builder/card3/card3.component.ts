import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';

import { NgFor } from '@angular/common';
import { ResturantModel } from '../../../models/resturantmodel';

@Component({
  selector: 'app-card3',
  standalone: true,
  imports: [NgFor],
  templateUrl: './card3.component.html',
  styleUrl: './card3.component.css',
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class Card3Component {
  resturants?:ResturantModel []=[
    new ResturantModel('a','a','a','a'),
    new ResturantModel('b','a','a','a'),
    new ResturantModel('c','a','a','a'),
    new ResturantModel('a','a','a','a'),
    new ResturantModel('b','a','a','a'),
    new ResturantModel('c','a','a','a'),
   ];
}
