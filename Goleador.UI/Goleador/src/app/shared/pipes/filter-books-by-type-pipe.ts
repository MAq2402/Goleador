import { Pipe, PipeTransform } from '@angular/core';
import { BookStatus } from '../enums/book-status.enum';
import { Book } from '../models/book';

@Pipe({ name: 'filterBooksByType' })
export class FilterBooksByTypePipe implements PipeTransform {
  transform(books: Book[], index: number) {
    if (!books || books.length === 0) {
      return [];
    }

    switch (index) {
        case 0:
            return books.filter(x => x.status === BookStatus.ToRead);
        case 1:
            return books.filter(x => x.status === BookStatus.InRead);
        case 2:
            return books.filter(x => x.status === BookStatus.Finished);
        default:
            return [];
    }
  }
}
