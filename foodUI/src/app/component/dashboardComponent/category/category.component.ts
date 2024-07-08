import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryService } from '../../../services/category/category.service';
import { error } from 'console';
import { categoryModel } from '../../../models/categoryModel';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [NgIf,ReactiveFormsModule,NgFor,CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  isModalOpen= false;
  isModalOpens= false;
  newCategory="";
  CategoryForm:any;
  CategoryDesForm:any;
  category:categoryModel[]=[];
  catid!:string;
  catName!:string;
  catauthorid!:string;

  constructor(private categoryService:CategoryService){}

ngOnInit(){
  this.getCategories();

  this.CategoryForm= new FormGroup({
   name: new FormControl(null,[Validators.required]),
  })

  this.CategoryDesForm= new FormGroup({
    id:new FormControl(null,[Validators.required]),
    name: new FormControl(null,[Validators.required]),

   })

}
openModalUpDel(cat:categoryModel){
  this.isModalOpens = true;
  this.catid=cat.id;
  this.catName=cat.categoryName;
  this.catauthorid=cat.authorId;

}
closeModalUpDel() {
  this.isModalOpens = false;
  this.CategoryForm.reset();
}

  openModal(){
    this.isModalOpen = true;
  }
  closeModal() {
    this.isModalOpen = false;
    this.CategoryForm.reset();
  }

  getCategories() {
    this.categoryService.getData('get').subscribe({
      next: (value: any) => {
        console.log(value);

       
        value.forEach((element: any) => {
          const category: categoryModel = {
            id: element.id,
            categoryName: element.categoryName,
            authorId: element.authorId
          };
          this.category.push(category); 
        });

        console.log('aaa',this.category); 
      },
      error: (error: any) => {
        console.error('Error:', error);
      }
    });
  }
  addCategory() {
    if (this.CategoryForm.valid) {
      const newCategory = {
        categoryName: this.CategoryForm.value.name

      };
      this.categoryService.postData('add',newCategory).subscribe({
        next:(value)=>{
          console.log("success",value);
          this.closeModal(); 
        },
        error:(error)=>{
          console.log("error",error);
        }
      })

      
    }
  }
  UpdateCategory(){
    if(this.CategoryDesForm.valid){
      const updatecat={
        Id:this.CategoryDesForm.value.id,
        CategoryName:this.CategoryDesForm.value.name,
      }
      this.categoryService.updateData('update',updatecat).subscribe({
        next:(value)=>{
          console.log("success",value);
          this.closeModalUpDel(); 
        },
        error:(error)=>{
          console.log("error",error);
        }
      })
    }
  }
  deleteCategories(id:string){
   this.categoryService.deleteData('delete',id).subscribe({
    next:(value)=>{
      console.log("success",value);
      this.closeModalUpDel(); 
    },
    error:(error)=>{
      console.log("error",error);
    }
   })
  }
}
