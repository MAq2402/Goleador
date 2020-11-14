import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoginCredentials } from 'src/app/shared/models/login-credentials.model';
import { LoginResponse } from 'src/app/shared/models/login-response.model';
import { User } from 'src/app/shared/models/user.model';

const TOKEN = 'token';
const ROUTE = `https://localhost:44323/api/auth/`;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSource = new Subject<User>();

  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  // register(model: RegisterModel): Observable<LoginResponseModel> {
  //   return this.http.post<LoginResponseModel>(`${ROUTE}register`, model).pipe(tap(token => {
  //     localStorage.setItem(TOKEN, token.authToken);
  //     this.announceNewUser();
  //   }));
  // }

  login(model: LoginCredentials): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${ROUTE}login`, model).pipe(tap(response => {
      localStorage.setItem(TOKEN, response.token);
      this.currentUserSource.next(response);
    }));
  }

  isLoggedIn(): boolean {
    console.log(localStorage.getItem(TOKEN));
    return !!localStorage.getItem(TOKEN);
  }

  logOut() {
    localStorage.removeItem(TOKEN);
    this.currentUserSource.next(null);
    this.router.navigate(['/login']);
  }
}
