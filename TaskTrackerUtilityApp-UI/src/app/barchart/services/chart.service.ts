import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ChartData } from '../models/chartData';
import { Observable } from 'rxjs';
import { Constants } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

url = Constants.CHART_API_URL;

constructor(private http: HttpClient) { }

public getChartData(): Observable<ChartData[]> {
  return this.http.get<ChartData[]>(this.url);
}

}
