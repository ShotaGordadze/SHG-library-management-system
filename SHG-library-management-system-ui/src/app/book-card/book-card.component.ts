import { Component } from '@angular/core';
import { Book } from '../book';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrl: './book-card.component.css'
})


export class BookCardComponent {
  book: Book; 

  constructor() {
    this.book = new Book();
  }
}



