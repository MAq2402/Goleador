import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { BookService } from 'src/app/core/services/book.service';
import { BookStatus } from 'src/app/shared/enums/book-status.enum';
import { Book } from 'src/app/shared/models/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  selectedTabIndex = 1;
  books: Book[];
  bookStatuses = BookStatus;
  constructor(private bookService: BookService, private changeDetecotor: ChangeDetectorRef) { }

  ngOnInit() {
    this.loadBooks().subscribe();

    this.bookService.bookAdded$.subscribe(() => this.loadBooks().subscribe(() => this.selectedTabIndex = 0));
  }

  onTabIndexChange(index: number) {
    this.selectedTabIndex = index;
  }

  startReading(id: string) {
    this.bookService.startReading(id).subscribe(() => {
      this.loadBooks().subscribe(() => {
        this.selectedTabIndex = 1;
        this.changeDetecotor.detectChanges();
      });
    });
  }

  doPomodoro(id: string) {
    this.bookService.doPomodoro(id).subscribe(() => {
      this.loadBooks().subscribe(() => this.changeDetecotor.detectChanges());
    });
  }

  finishReading(id: string) {
    this.bookService.finishReading(id).subscribe(() => {
      this.loadBooks().subscribe(() => {
        this.selectedTabIndex = 2;
        this.changeDetecotor.detectChanges();
      });
    });
  }

  private loadBooks(): Observable<Book[]> {
    return this.bookService.getBooks().pipe(tap(books => {
      this.books = books;
      return this.books;
    }));
  }
}
