import { Component } from '@angular/core';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsModule, FormControl, FormGroup } from '@angular/forms';
import { Book } from '../book';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css'
})
export class BookFormComponent {
  bookForm = new FormGroup({
    image: new FormControl(''),
    name: new FormControl('', [Validators.required]),
    subject: new FormControl('', [Validators.required]),
    author: new FormControl('', [Validators.required]),
  });

  get image() {
    return this.bookForm.get('image');
  }
  get name() {
    return this.bookForm.get('name');
  }
  get subject() {
    return this.bookForm.get('subject');
  }
  get author() {
    return this.bookForm.get('author');
  }

  book = new Book;
  submit() {
    const { name, subject, author } = this.bookForm.value;
    this.book.name = name ?? '';
    this.book.subject = subject ?? '';
    this.book.author = author ?? '';
    console.log(this.book);
  }
  
 //USED FOR IMAGE UPLOAD (base64)
 imageData: any = '';
 onImgSelected(event: any) {
   const file: File = event.target.files[0];
   const reader = new FileReader();

   reader.onload = (e) => {
     const imageUrl: string | ArrayBuffer | null = e.target?.result ?? null;

     if (this.isImageFile(file)) {
       this.imageData = imageUrl;
       this.book.image=this.imageData;
     }
   };

   reader.readAsDataURL(file);
 }

 isImageFile(file: File): boolean {
   return file.type.startsWith('image/');
 }
 //USED FOR IMAGE UPLOAD (base64)

}
