import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './pages/dashboard.component';
import { DashboardOutletDirective } from './dashboard-outlet.directive';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  imports: [
    CommonModule, MatCardModule
  ],
  declarations: [DashboardComponent, DashboardOutletDirective]
})
export class DashboardModule { }
