import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/pages/value.component';
import { LinechartComponent } from './linechart/pages/linechart.Component';
import { ChartService } from './linechart/services/chart.service';
import { BarchartComponent } from './barchart/pages/barchart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BarChartContainer } from './barchart/pages/barchart-container';
import { LineChartContainer } from './linechart/pages/linechart-container';
import { NavComponent } from './nav/pages/nav.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { AuthService } from './_services/auth.service';


@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      LinechartComponent,
      BarchartComponent,
      BarChartContainer,
      LineChartContainer,
      NavComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      DashboardModule,
      FormsModule
   ],
   providers: [
      ChartService,
      AuthService
   ],
   bootstrap: [
      AppComponent
   ],
   entryComponents: [
      BarChartContainer,
      LineChartContainer
   ]
})
export class AppModule { }
