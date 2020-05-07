import { Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { HttpClientModule, HttpClient , HttpEventType, HttpHeaders} from '@angular/common/http';
import { observable } from 'rxjs';
import { FormBuilder, FormGroup, NgModel } from  '@angular/forms';
import { environment } from 'src/environments/environment';

import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { AngularFireStorage } from '@angular/fire/storage';
import { mapTo, finalize } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmationDialog } from '../shared/ConfirmationDialog';
@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {


  constructor(private http: HttpClient, private storage: AngularFireStorage, 
              private dialog: MatDialog, private snackBar: MatSnackBar) { }

  // tslint:disable-next-line:no-input-rename
  @Input('taskId') taskId: number;
  @Output('uploadedFile') change = new EventEmitter();

  fileData: File = null;
  files: FileUploadModel[];

  userId = 1;
  uploadResponse = { uploadResponse: '', message: '', filePath: '' };
  lastmodifieddate: number;
  size: number;
  filename: string;
  Filetype: any;
  uploadProgress: any;
  downloadURL: any;
  fileList: any[];
  filepath: any;
  imageURL: any;
  SuccessDiv = true;
  private model: FileUploadModel;

  ngOnInit(): void {
    this.getAttachments();
  }

getAttachments() {
  if(this.taskId != undefined)
  {
    this.http.get<FileUploadModel[]>(environment.apiUrl + 'File/' + this.taskId).subscribe(
      (data) => {
        this.files = data;
      });
  }
}

upload(event) {
  const file = event.target.files[0];
  this.lastmodifieddate = file.lastModified;
  this.size = file.size;
  this.filename = file.name;
  this.Filetype = file.type;

  const id = Math.random().toString(36).substring(2);
  this.filepath = `${this.filename}`;
  const ref = this.storage.ref(this.filepath);
  this.storage.upload(this.filepath, event.target.files[0]).snapshotChanges().pipe(
     finalize(() => {
       ref.getDownloadURL().subscribe((url) => {
         console.log(url);
         this.imageURL = url;
         this.model = new FileUploadModel();
         this.model.fileName = this.filename;
         this.model.filePath = this.imageURL;
         this.model.fileType = this.Filetype;
         this.model.taskId = this.taskId;
         this.SuccessDiv = false;
         this.change.emit({ attachment: this.model});
     });
  })
  ).subscribe();

  const task =   ref.put(event.target.files[0]);
  this.uploadProgress = task.percentageChanges();
}

showDeleteConfirmation(id: number, imageURL?: string, fileName?: string, file?: FileUploadModel) {
  let name = !!fileName ? fileName : file.fileName;
  const dialogRef = this.dialog.open(ConfirmationDialog, {
    data:{
      message: 'Are you sure you want to delete '+ name +' ?',
      buttonText: {
        ok: 'Yes',
        cancel: 'No'
      }
    }
  });
  dialogRef.afterClosed().subscribe((confirmed: boolean) => {
    if (confirmed && id > 0) {

      this.http.delete(environment.apiUrl + 'File/' + id).subscribe(data => {
          this.snackBar.open('File deleted!', '', {
              duration: 2000,
            // tslint:disable-next-line:align
            });
      }); 
    }
    const downloadUrl = !!imageURL ? imageURL : file.filePath;
    this.storage.storage.refFromURL(downloadUrl).delete();
    this.getAttachments();
  });
  
}


}

export class FileUploadModel {
  fileName: string;
  fileType: string;
  filePath: string;
  taskId: number;
  id?: number;
}

export interface FileUploadedEventArgs {
  attachment: FileUploadModel;
}




