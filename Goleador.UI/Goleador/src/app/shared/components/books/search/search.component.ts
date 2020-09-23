import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';;
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { BookService } from 'src/app/core/services/book.service';
import { BookSearchItem } from 'src/app/shared/models/book-search-item';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {

  searchControl = new FormControl();
  books: BookSearchItem[];

  constructor(private bookService: BookService) {
    this.searchControl.valueChanges
      .pipe(
        debounceTime(400),
        distinctUntilChanged(),
        switchMap(term => {
          if (term && term.length > 2) {
            return this.bookService.searchBooks(term);
          } else {
            this.books = [];
          }
        }
      )).subscribe(books => this.books = books);
  }
}
