import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './pages/dashboard.component';
import { DashboardOutletDirective } from './dashboard-outlet.directive';
import { MatCardModule } from '@angular/material/card';
import { DashboardCardComponent } from './pages/dashboard-card/dashboard-card.component';
import { DashboardCardContainer } from './pages/dashboard-card/dashboard-card.container';

@NgModule({
  imports: [
    CommonModule, MatCardModule
  ],
  declarations: [DashboardComponent, DashboardOutletDirective, DashboardCardComponent, DashboardCardContainer],
  exports: [DashboardComponent]
})
export class DashboardModule { }
