import { BookStatus } from '../enums/book-status.enum';

export interface BookForCreation {
    title: string;
    authors: string[];
    thumbnail: string;
    publishedYear: string;
    externalId: string;
}

export interface Book {
    id: string;
    title: string;
    authors: string;
    status: BookStatus;
    thumbnail: string;
    publishedYear: string;
    externalId: string;
    created: Date | string;
    readingStarted: Date | string | null;
    readingFinished: Date | string | null;
    pomodoros: any[];
}
