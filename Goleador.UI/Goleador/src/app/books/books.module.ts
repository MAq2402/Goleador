import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books/books.component';
import { AddBookDialogComponent } from './add-book-dialog/add-book-dialog.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [BooksComponent, AddBookDialogComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    BooksComponent,
    AddBookDialogComponent
  ],
  entryComponents: [
    AddBookDialogComponent
  ]
})
export class BooksModule { }
