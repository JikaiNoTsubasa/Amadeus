import { HttpRequest, HttpHandlerFn, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { inject } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { AuthService } from "./AuthService";

export function provideBearerInterceptor(req: HttpRequest<any>, next: HttpHandlerFn): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('token');
    const authService = inject(AuthService);

    if (token) {
        req = req.clone({
            setHeaders: {
                Authorization: `Bearer ${token}`
            }
        });
    }

    return next(req).pipe(
        catchError((err: HttpErrorResponse) => {
          if (err.status === 401) {
            console.log('401 Unauthorized - Déconnexion automatique');
            authService.logout();
          }
          return throwError(() => err);
        })
      );
}