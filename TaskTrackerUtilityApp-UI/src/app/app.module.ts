import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import {MatTableModule} from '@angular/material/table';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatDialogModule} from '@angular/material/dialog';
import { FlexLayoutModule } from '@angular/flex-layout';

import { DashboardModule } from './dashboard/dashboard.module';
import { AuthService } from './_services/auth.service';
import { FileUploadComponent } from './file-upload/file-upload.component';
import {AngularFireModule} from '@angular/fire';
import {AngularFireStorageModule} from '@angular/fire/storage';
import { NgxFileDropModule } from 'ngx-file-drop';
import { environment} from '../environments/environment';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ConfirmationDialog } from './shared/ConfirmationDialog';
import { TasksComponent } from './tasks/pages/tasks.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker'

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
      FileUploadComponent,
      UserComponent,
      NavComponent,
      FileUploadComponent,
      ConfirmationDialog,
      TasksComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      DashboardModule,
      FormsModule,
      AgGridModule.withComponents([]),
      DashboardModule,
      AppRoutingModule,
      NgxFileDropModule,
      AngularFireModule.initializeApp(environment.firebaseConfig),
      AngularFireStorageModule,
      MatGridListModule,
      MatTableModule,
      MatIconModule,
      MatButtonModule,
      MatDialogModule,
      MatFormFieldModule,
      ReactiveFormsModule,
      MatCardModule,
      MatInputModule,
      FlexLayoutModule,
      MatCheckboxModule,
      MatSelectModule,
      MatSnackBarModule,
      MatToolbarModule,
      BsDatepickerModule.forRoot()
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
      LineChartContainer,
      ConfirmationDialog
   ]
})
export class AppModule { }
