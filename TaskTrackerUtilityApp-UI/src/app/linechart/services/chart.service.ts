import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskCountByProgress } from '../models/taskCountByProgress';
import { Observable } from 'rxjs';
import { Constants } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

url = Constants.TASK_PROGRESS_API_URL;

constructor(private http: HttpClient) { }

public getChartData(): Observable<TaskCountByProgress[]> {
  return this.http.get<TaskCountByProgress[]>(this.url);
}

}
