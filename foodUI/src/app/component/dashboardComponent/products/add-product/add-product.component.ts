import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [AddProductComponent,RouterModule,ReactiveFormsModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent {

 
  addProductForm:any;
  img:any;

  constructor(){}

  ngOnInit(){
    this.addProductForm = new FormGroup({
      name:new FormControl(null,[Validators.required]),
      description:new FormControl(null,[Validators.required]),
      address:new FormControl(null,[Validators.required]),
      quantity:new FormControl(null,[Validators.required]),
      price:new FormControl(null,[Validators.required]),
      category:new FormControl(null,[Validators.required]),
      image:new FormControl(null,[Validators.required]),
      outOfStock:new FormControl(null,[Validators.required]),
      
    });
  }
  onFileSelected(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.img = reader.result; // Set img to base64 data URI
     
      };
    }
  }
 
  OnFormSubmitted(){
   
  
 
  }

}
