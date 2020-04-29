import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { value } from '../models/value';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: value[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get<value[]>('http://localhost:5000/api/values').subscribe( data => {
      this.values = data;
    }, error => {
      console.log(error);
    });
  }

}
