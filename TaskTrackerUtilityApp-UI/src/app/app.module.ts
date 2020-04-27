import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValueComponent } from './value/value.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import {AngularFireModule}  from "@angular/fire";
import {AngularFireStorageModule}  from "@angular/fire/storage";
import { NgxFileDropModule } from 'ngx-file-drop';
import { environment} from "../environments/environment"

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      FileUploadComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      NgxFileDropModule,
      AngularFireModule.initializeApp(environment.firebaseConfig),
      AngularFireStorageModule
       
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
