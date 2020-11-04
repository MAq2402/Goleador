import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { BookService } from 'src/app/core/services/book.service';
import { Book } from 'src/app/shared/models/book';
import { BookSearchItem } from 'src/app/shared/models/book-search-item';

@Component({
  selector: 'app-add-book-dialog',
  templateUrl: './add-book-dialog.component.html',
  styleUrls: ['./add-book-dialog.component.scss']
})
export class AddBookDialogComponent implements OnInit {

  private selectedBook: Book;
  constructor(public dialogRef: MatDialogRef<AddBookDialogComponent>, private bookService: BookService) { }

  ngOnInit() {
  }

  onBookSelected(book: BookSearchItem) {
    this.selectedBook = {
      authors: book.authors,
      externalId: book.id,
      publishedYear: new Date(book.publishedDate).getFullYear().toString(),
      thumbnail: book.thumbnail,
      title: book.title
    };
  }

  add() {
    this.bookService.addBook(this.selectedBook).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
