import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskCountByProgress } from '../models/taskCountByProgress';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

constructor(private http: HttpClient) { }

public getChartData(): Observable<TaskCountByProgress[]> {
  return this.http.get<TaskCountByProgress[]>(environment.apiUrl + 'dashboard/taskByProgress');
}

}
