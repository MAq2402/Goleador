import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs/operators';
import { BookService } from 'src/app/core/services/book.service';
import { BookStatus } from '../../enums/book-status.enum';
import { BookSearchItem } from '../../models/book-search-item';
import { SearchComponent } from '../books/search/search.component';

@Component({
  selector: 'app-pomodoro',
  templateUrl: './pomodoro.component.html',
  styleUrls: ['./pomodoro.component.scss']
})
export class PomodoroComponent implements OnInit {

  shortBreak = 5;
  longBreak = 10;
  pomodoro = 25;
  currentTimerType = this.pomodoro;
  timerValueMinutes = this.currentTimerType;
  timerValueSeconds = 0;
  interval;
  countingDown = false;
  selectedBook: BookSearchItem;
  books: BookSearchItem[];

  @ViewChild(SearchComponent, {static: false}) bookSearch: SearchComponent;

  constructor(private bookService: BookService) {}

  ngOnInit() {
    this.bookService.getBooks().pipe(map(books => {
      return books.filter(b => b.status === BookStatus.InRead).map<BookSearchItem>(x => {
        return {
          title: x.title,
          thumbnail: x.thumbnail,
          authors: x.authors.split(','),
          publishedDate: x.publishedYear,
          id: x.externalId,
          domainId: x.id
        };
      });
    })).subscribe(books => this.books = books);
  }

  play() {
    if (!this.countingDown) {
      this.countingDown = true;
      this.interval = setInterval(() => {
        this.timerValueSeconds -= 1;
        if (this.timerValueSeconds < 0) {
          this.timerValueSeconds = 59;
          this.timerValueMinutes -= 1;
        }
        if (this.timerValueMinutes === 0 && this.timerValueSeconds === 0) {
          this.stop();
          this.playSound();
          if (this.selectedBook) {
            this.bookService.doPomodoro(this.selectedBook.domainId).subscribe();
          }
        }
      }, 1000);
    }
  }

  private playSound() {
    const audio = new Audio();
    audio.src = 'assets/audio/alarm.wav';
    audio.load();
    audio.play();
  }

  stop() {
    clearInterval(this.interval);
    this.countingDown = false;
  }

  reset(value: number = null) {
    this.timerValueMinutes = value ? value : this.currentTimerType;
    this.currentTimerType = this.timerValueMinutes;
    this.timerValueSeconds = 0;
    this.stop();
    this.selectedBook = null;
    this.bookSearch.clear();
  }

  onBookSelected(book: BookSearchItem) {
    this.selectedBook = book;
  }
}
