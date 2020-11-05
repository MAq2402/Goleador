import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AddBookDialogComponent } from 'src/app/books/add-book-dialog/add-book-dialog.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  pomodoroOpened = false;
  constructor(public dialog: MatDialog) { }

  ngOnInit() {
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
}
