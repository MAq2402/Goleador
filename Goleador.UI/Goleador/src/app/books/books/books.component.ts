import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { BookService } from 'src/app/core/services/book.service';
import { SignalRService } from 'src/app/core/services/signal-r.service';
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
  constructor(private bookService: BookService, private changeDetecotor: ChangeDetectorRef, private signalRService: SignalRService) { }

  ngOnInit() {
    this.loadBooks().subscribe();
    this.signalRService.startBookConnection();
    this.signalRService.subscribeToBooks();
    this.signalRService.books$.subscribe(books => {
      console.log(books);
      this.books = books;
      this.changeDetecotor.detectChanges();
    });

    this.bookService.bookAdded$.subscribe(() => {
      this.selectedTabIndex = 0;
      this.changeDetecotor.detectChanges();
    });
  }

  onTabIndexChange(index: number) {
    this.selectedTabIndex = index;
  }

  startReading(id: string) {
    this.bookService.startReading(id).subscribe(() => {
      this.selectedTabIndex = 1;
      this.changeDetecotor.detectChanges();
    });
  }

  doPomodoro(id: string) {
    this.bookService.doPomodoro(id).subscribe();
  }

  finishReading(id: string) {
    this.bookService.finishReading(id).subscribe(() => {
      this.selectedTabIndex = 2;
      this.changeDetecotor.detectChanges();
    });
  }

  private loadBooks(): Observable<Book[]> {
    return this.bookService.getBooks().pipe(tap(books => {
      this.books = books;
      return this.books;
    }));
  }
}
