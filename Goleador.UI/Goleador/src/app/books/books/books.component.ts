import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/core/services/book.service';
import { Book } from 'src/app/shared/models/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  books: Book[];
  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.loadBooks();

    this.bookService.bookAdded$.subscribe(() => this.loadBooks());
  }


  private loadBooks() {
    this.bookService.getBooks().subscribe(books => {
      this.books = books;
    });
  }
}
