import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient) { }

login(model: any) {
  return this.http.post(environment.apiUrl + 'login/Authenticate', model)
  .pipe(
    catchError((error: HttpErrorResponse) => 
      throwError(error)
    ))
  .pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.userToken);
      }
    })
    );
}

}
