import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskCountByStatus } from '../models/taskCountByStatus';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

constructor(private http: HttpClient) { }

public getChartData(): Observable<TaskCountByStatus[]> {
  return this.http.get<TaskCountByStatus[]>(environment.apiUrl + 'dashboard/taskByStatus');
}

}
