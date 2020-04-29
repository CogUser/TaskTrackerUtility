import { Component, OnInit } from '@angular/core';
import { TaskCountByStatus } from '../models/taskCountByStatus';
import { ChartService } from '../services/chart.service';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {

  taskStatus = [];
  taskCount = [];
  barchart: Chart;
  dataSource: TaskCountByStatus[];

  constructor(private chartService: ChartService) { }

  ngOnInit() {
    this.chartService.getChartData().subscribe((chartData: TaskCountByStatus[]) => {
      this.dataSource = chartData;
      chartData.forEach(item => {
      this.taskStatus.push(item.taskStatus);
      this.taskCount.push(item.taskCountByStatus);
    });
      this.barchart = new Chart('canvas_bar', {
      type: 'doughnut',
      data: {
        labels: this.taskStatus,
        datasets: [
          {
            data: this.taskCount,
            borderColor: '#3cba9f',
            backgroundColor: [
              '#3cb371',
              '#0000FF',
              '#9966FF',
              '#4C4CFF',
              '#00FFFF',
              '#f990a7',
              '#aad2ed',
              '#FF00FF',
              'Blue',
              'Red',
              'Blue'
            ],
            fill: true
          }
        ]
      },
      options: {
        legend: {
          display: true,
        position: 'bottom',
        labels: {
        fontColor: '#000080',
      }
        },
        scales: {
          xAxes: [{
            display: false
          }],
          yAxes: [{
            display: false
          }],
        }
      }
    });
  });
  }
  }


