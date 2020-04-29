import { Component, OnInit } from '@angular/core';
import { ChartData } from '../models/chartData';
import { ChartService } from '../services/chart.service';
import * as Chart from 'chart.js';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {

  player = [];
  run = [];
  barchart: Chart;

  constructor(private chartService: ChartService) { }

  ngOnInit() {
    this.chartService.getChartData().subscribe((chartData: ChartData[]) => {
      chartData.forEach(item => {
      this.player.push(item.playerName);
      this.run.push(item.run);
    });
      this.barchart = new Chart('canvas_bar', {
      type: 'bar',
      data: {
        labels: this.player,
        datasets: [
          {
            data: this.run,
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
          display: false
        },
        scales: {
          xAxes: [{
            display: true
          }],
          yAxes: [{
            display: true
          }],
        }
      }
    });
  });
  }
  }


