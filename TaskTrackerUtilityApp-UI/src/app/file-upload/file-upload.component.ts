import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient , HttpEventType, HttpHeaders} from '@angular/common/http';
import { observable } from 'rxjs';
import { FormBuilder, FormGroup, NgModel } from  '@angular/forms';
import { environment } from 'src/environments/environment';

import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { AngularFireStorage } from '@angular/fire/storage';
import { mapTo, finalize } from 'rxjs/operators';
@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {


  constructor(private http: HttpClient, private storage: AngularFireStorage) { }

  fileData: File = null;

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
         this.model.taskId = 9;// To do: pass taskid from parent
         this.http.post('http://localhost:5000/api/' + 'File', this.model).subscribe(data => {
            console.log('Added file Attachment'); // environment.apiUrl
          });
     })
  })
  ).subscribe();

  const task =   ref.put(event.target.files[0]);
  this.uploadProgress = task.percentageChanges();
}

onSubmit(comment: string) {
console.log(this.imageURL);
console.log(comment);
this.SuccessDiv = false;


this.http.post<any>('', JSON.stringify(this.model)).subscribe(data => {
});

}

}


export class FileUploadModel {
  fileName: string;
  fileType: string;
  filePath: string;
  taskId: number;
}



