import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { Book } from 'src/app/shared/models/book';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private booksSubject$ = new Subject<Book[]>();
  private hubConnection: signalR.HubConnection;

  books$ = this.booksSubject$.asObservable();
  options: signalR.IHttpConnectionOptions = {
    accessTokenFactory: () => {
      return localStorage.getItem('token');
    }
  };

  startBookConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44323/hub/books', this.options)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  subscribeToBooks() {
    this.hubConnection.on('books', (data) => {
      console.log(data);
      this.booksSubject$.next(data);
    });
  }
}
