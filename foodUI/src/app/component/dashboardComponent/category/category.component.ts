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
  newCategory="";
  CategoryForm:any;
  category:categoryModel[]=[];

  constructor(private categoryService:CategoryService){}

ngOnInit(){
  this.getCategories();

  this.CategoryForm= new FormGroup({
   CategoryName: new FormControl(null,[Validators.required]),
  })
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
        name: this.CategoryForm.get('CategoryName')?.value
      };

      this.closeModal(); 
    }
  }
}
