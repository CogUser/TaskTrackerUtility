import { Injectable, Inject } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpResponse,
    HttpHandler,
    HttpEvent,
    HttpErrorResponse
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ErrorDialogService } from '../_services/error-dialog.service';
import { TaskAppError } from '../error-dialog/taskAppError';

@Injectable({
    providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

constructor(@Inject(ErrorDialogService)private errorDialogService: ErrorDialogService) {}

intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token: string = localStorage.getItem('token');
    if (token) {
        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
    }
    if (!request.headers.has('Content-Type')) {
        request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
    }
    request = request.clone({ headers: request.headers.set('Accept', 'application/json') });

    return next.handle(request).pipe(
        catchError((error) => {
            const data = new TaskAppError();
            if (error.status === 401) {
                data.reason = error.statusText;
            }
            if (error instanceof HttpErrorResponse) {
                data.reason = error && error.message ? error.message : '';
            }
            data.status = error.status;
            this.errorDialogService.openDialog(data);
            return throwError(error);
        }),
        map((event: HttpEvent<any>) => {
            if (event instanceof HttpResponse) {
                console.log('event--->>>', event);
            }
            return event;
        })
        );
}

}
