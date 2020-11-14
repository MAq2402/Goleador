import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { SpinnerService } from '../services/spinner.service';

@Injectable()
export class SpinnerInterceptor implements HttpInterceptor {
    private excludedRequests: {method: string, url: string}[] = [
        { method: 'GET', url: 'api/books/search?query' }
    ];

    constructor(private spinnerService: SpinnerService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.excludedRequests.some(x => x.method === req.method && req.url.includes(x.url))) {
            return next.handle(req);
        }

        this.spinnerService.show();
        return next.handle(req).pipe(
            finalize(() => this.spinnerService.hide())
        );
    }
}
