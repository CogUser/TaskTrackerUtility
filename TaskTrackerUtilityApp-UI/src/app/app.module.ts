import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/pages/value.component';
import { LinechartComponent } from './linechart/pages/linechart.Component';
import { ChartService } from './linechart/services/chart.service';
import { BarchartComponent } from './barchart/pages/barchart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BarChartContainer } from './barchart/pages/barchart-container';
import { LineChartContainer } from './linechart/pages/linechart-container';
import { NavComponent } from './nav/pages/nav.component';
import { UserComponent } from './user/pages/user.component';
import { AgGridModule } from 'ag-grid-angular';

import { DashboardModule } from './dashboard/dashboard.module';
import { AuthService } from './_services/auth.service';
import { FileUploadComponent } from './file-upload/file-upload.component';
import {AngularFireModule} from '@angular/fire';
import {AngularFireStorageModule} from '@angular/fire/storage';
import { NgxFileDropModule } from 'ngx-file-drop';
import { environment} from '../environments/environment';

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      LinechartComponent,
      BarchartComponent,
      BarChartContainer,
      LineChartContainer,
      UserComponent,
      NavComponent,
      FileUploadComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BrowserAnimationsModule,
      DashboardModule,
      FormsModule,
      AgGridModule.withComponents([]),
      DashboardModule,
      AppRoutingModule,
      NgxFileDropModule,
      AngularFireModule.initializeApp(environment.firebaseConfig),
      AngularFireStorageModule
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
