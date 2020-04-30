import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskCountByStatus } from '../models/taskCountByStatus';
import { Observable } from 'rxjs';
import { Constants } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

url = Constants.TASK_STATUS_API_URL;

constructor(private http: HttpClient) { }

public getChartData(): Observable<TaskCountByStatus[]> {
  return this.http.get<TaskCountByStatus[]>(this.url);
}

}
