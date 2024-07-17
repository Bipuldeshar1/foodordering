import { FoodModel } from "./foodModel";

export class CartModel{
    constructor(public food:FoodModel,public quantity:number, ){}
}