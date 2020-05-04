import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TaskAppError } from './taskAppError';

@Component({
  selector: 'app-root',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.css']
})
export class ErrorDialogComponent {
  errorData: TaskAppError;
  constructor(@Inject(MAT_DIALOG_DATA) public data: TaskAppError) {
    this.errorData = data;
  }
}
