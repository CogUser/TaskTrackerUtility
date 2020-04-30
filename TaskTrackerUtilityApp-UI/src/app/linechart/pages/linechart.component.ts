import { Component, OnInit } from '@angular/core';
import { TaskCountByProgress } from '../models/taskCountByProgress';
import { ChartService } from '../services/chart.service';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-linechart',
  templateUrl: './linechart.component.html',
  styleUrls: ['./linechart.component.css']
})
export class LinechartComponent implements OnInit {

  taskProgress = [];
  taskCountByProgress = [];
  linechart: Chart;

  constructor(private chartService: ChartService) { }

  ngOnInit() {
    this.chartService.getChartData().subscribe((chartData: TaskCountByProgress[]) => {
      chartData.forEach(item => {
      this.taskProgress.push(item.taskProgress.toString() + '%');
      this.taskCountByProgress.push(item.taskCountByProgress);
    });
      this.linechart = new Chart('canvas', {
      type: 'line',
      data: {
        labels: this.taskProgress,
        datasets: [
          {
            data: this.taskCountByProgress,
            borderColor: '#3cb371',
            backgroundColor: '#0000FF'
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        scales: {
          xAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              labelString: 'Completion percentage'
            },
          gridLines: {
            display: false,
            drawBorder: false
         }
          }],
          yAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              labelString: 'Task Count'
            },
            ticks: {
              beginAtZero: true
          }
          }]
        }
      }
    });
  });
  }
}
