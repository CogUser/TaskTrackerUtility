import { Component, OnInit } from '@angular/core';
import { ChartData } from '../models/chartData';
import { ChartService } from '../services/chart.service';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-linechart',
  templateUrl: './linechart.component.html',
  styleUrls: ['./linechart.component.css']
})
export class LinechartComponent implements OnInit {

  player = [];
  run = [];
  linechart: Chart;

  constructor(private chartService: ChartService) { }

  ngOnInit() {
    this.chartService.getChartData().subscribe((chartData: ChartData[]) => {
      chartData.forEach(item => {
      this.player.push(item.playerName);
      this.run.push(item.run);
    });
      this.linechart = new Chart('canvas', {
      type: 'line',
      data: {
        labels: this.player,
        datasets: [
          {
            data: this.run,
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
            display: true
          }],
          yAxes: [{
            display: true
          }]
        }
      }
    });
  });
  }
}
