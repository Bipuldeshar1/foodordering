export class FoodModel {
    constructor(
      public name: string,
      public description: string,
      public imageUrl: string,
      public price: number,
      public quality: number,
      public address: string,
      public outOfStock: boolean,
      public categoryId: string
    ) {}
  }
  