import { NgClass } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [NgClass,RouterModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  NavVisible=false;

  onNavShow(){
  this.NavVisible=!this.NavVisible;
  }
}

// <app-banner></app-banner>
// <div class="md:mt-8">
//   <h1 class="my-8 font-extrabold text-3xl font-poppins flex justify-between">
//     Up to -40% 🎊 Order.uk exclusive deals
//     <span
//       class="text-blue-600 text-sm relative top-3 cursor-pointer hover:text-[#FC8A06]"
//     >
//       see all</span
//     >
//   </h1>

//   <app-card1></app-card1>
// </div>

// <div class="mt-5 p-5 sm:bg-[#D9D9D9] lg:bg-white">
//   <h1
//     class="my-8 font-extrabold text-3xl font-poppins flex justify-between cursor-pointer"
//   >
//     Order.uk Popular Categories 🤩
//     <span class="text-blue-600 text-sm relative top-3 hover:text-[#FC8A06]">
//       see all</span
//     >
//   </h1>
//   <app-card2></app-card2>
// </div>
// <div>
//   <h1
//     class="my-8 font-extrabold text-3xl font-poppins flex justify-between cursor-pointer"
//   >
//     Popular Restaurants
//     <span class="text-blue-600 text-sm relative top-3 hover:text-[#FC8A06]">
//       see all</span
//     >
//   </h1>
//   <app-card3></app-card3>
// </div>

// <div>
//   <app-banner2></app-banner2>
// </div>
// </div>