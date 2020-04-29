import { Component } from '@angular/core';
import { DashboardCardContainer } from '../../dashboard/pages/dashboard-card/dashboard-card.container';

@Component({
    template: `
      <app-linechart></app-linechart>
    `,
  })
// tslint:disable-next-line:component-class-suffix
export class LineChartContainer extends DashboardCardContainer {}
