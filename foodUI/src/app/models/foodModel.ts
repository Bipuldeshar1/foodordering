import { categoryModel } from "./categoryModel";

export class FoodModel {
    constructor(
      public id:string,
      public name: string,
      public description: string,
      public imageUrl: string,
      public price: number,
      public quantity: number,
      public address: string,
      public outOfStock: boolean,
      public categoryName: string,
      public category: categoryModel
    ) {}
  }
  