import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material';
import { Observable, of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, switchMap } from 'rxjs/operators';
import { BookService } from 'src/app/core/services/book.service';
import { BookSearchItem } from 'src/app/shared/models/book-search-item';

@Component({
  selector: 'app-book-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  searchControl = new FormControl();
  selectedBook: BookSearchItem;
  filteredBooks: Observable<BookSearchItem[]>;

  @Output() bookSelected = new EventEmitter<BookSearchItem>();
  @Input() searchInOwnCollection = false;
  @Input() books: BookSearchItem[] = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    if (this.searchInOwnCollection) {
      this.filteredBooks = this.searchControl.valueChanges
        .pipe(
          startWith(''),
          map(value => value ? this.filterBooks(value) : this.books.slice())
        );
    } else {
      this.filteredBooks = this.searchControl.valueChanges
        .pipe(
          debounceTime(400),
          distinctUntilChanged(),
          switchMap(term => {
            if (term && term.length > 2) {
              return this.bookService.searchBooks(term).pipe(catchError(err => of([])));
            } else {
              return of([]);
            }
          }
          ));
    }
  }

  private filterBooks(value: string): BookSearchItem[] {
    const filterValue = value.toLowerCase();

    return this.books.filter(b => b.title.toLowerCase().indexOf(filterValue) === 0);
  }

  onSelect(event: MatAutocompleteSelectedEvent) {
    this.selectedBook = event.option.value;
    this.bookSelected.emit(this.selectedBook);
    this.searchControl.setValue(`${this.selectedBook.title}`);
  }

  clear() {
    this.searchControl.setValue('');
    this.selectedBook = null;
  }
}
