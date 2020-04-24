import { Component } from '@angular/core';
import { DashboardCardContainer } from '../../dashboard/pages/dashboard-card/dashboard-card.container';

@Component({
  template: `
    <app-barchart></app-barchart>
  `,
})
// tslint:disable-next-line:component-class-suffix
export class BarChartContainer extends DashboardCardContainer {}
