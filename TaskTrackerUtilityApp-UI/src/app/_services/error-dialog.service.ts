import { Injectable } from '@angular/core';
import { ErrorDialogComponent } from '../error-dialog/error-dialog.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Injectable({
  providedIn: 'root'
})
export class ErrorDialogService {

constructor(public dialog: MatDialog) { }

public openDialog(data): void {
  const dialogRef = this.dialog.open(ErrorDialogComponent, {
    width: '400px',
    data
  });

  dialogRef.afterClosed().subscribe( m =>
    console.log('Error dialog closed')
  );
}

}
