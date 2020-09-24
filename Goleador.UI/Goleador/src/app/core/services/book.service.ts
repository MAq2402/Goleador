import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Book } from 'src/app/shared/models/book';
import { BookSearchItem } from 'src/app/shared/models/book-search-item';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseUrl = 'https://localhost:44323/api/books';
  constructor(private http: HttpClient) { }

  getBooks(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }

  searchBooks(query: string): Observable<BookSearchItem[]> {
    return this.http.get<any>(`${this.baseUrl}/search?query=${query}`).pipe(map(response => response.items));
  }

  addBook(book: Book): Observable<any> {
    return this.http.post(`${this.baseUrl}`, book);
  }
}
