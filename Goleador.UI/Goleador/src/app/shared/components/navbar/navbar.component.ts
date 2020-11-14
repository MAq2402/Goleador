import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AddBookDialogComponent } from 'src/app/books/add-book-dialog/add-book-dialog.component';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  pomodoroOpened = false;
  isUserLogged = false;
  constructor(public dialog: MatDialog, private authService: AuthService) { }

  ngOnInit() {
    this.authService.currentUser$.subscribe(() => {
      this.isUserLogged = this.authService.isLoggedIn();
    });
  }

  openAddBookDialog(): void {
    const dialogRef = this.dialog.open(AddBookDialogComponent, {
      width: '700px',
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  togglePomodoro() {
    this.pomodoroOpened = !this.pomodoroOpened;
  }

  logOut() {
    this.authService.logOut();
  }
}
