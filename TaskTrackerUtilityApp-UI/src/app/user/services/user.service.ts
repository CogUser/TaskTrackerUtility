import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserData } from '../models/userData';
import { Observable } from 'rxjs';
import { Constants } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class UserService {

url = Constants.USER_API_URL;

constructor(private http: HttpClient) { }

public getUserData(): Observable<UserData[]> {
  return this.http.get<UserData[]>(this.url);
}

}
