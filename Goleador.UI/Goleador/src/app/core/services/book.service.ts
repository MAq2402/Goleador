import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Book, BookForCreation } from 'src/app/shared/models/book';
import { BookSearchItem } from 'src/app/shared/models/book-search-item';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseUrl = 'https://localhost:44323/api/books';
  private bookAddedSubject = new Subject<void>();

  public bookAdded$ = this.bookAddedSubject.asObservable();

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseUrl}`);
  }

  searchBooks(query: string): Observable<BookSearchItem[]> {
    return this.http.get<any>(`${this.baseUrl}/search?query=${query}`).pipe(map(response => response.items));
  }

  addBook(book: BookForCreation): Observable<any> {
    return this.http.post(`${this.baseUrl}`, book).pipe(tap(() => this.bookAddedSubject.next()));
  }

  doPomodoro(bookId: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/${bookId}/pomodoros`, {});
  }

  startReading(bookId: string): Observable<any> {
    return this.http.put(`${this.baseUrl}/startReading/${bookId}`, {});
  }

  finishReading(bookId: string): Observable<any> {
    return this.http.put(`${this.baseUrl}/finishReading/${bookId}`, {});
  }
}
