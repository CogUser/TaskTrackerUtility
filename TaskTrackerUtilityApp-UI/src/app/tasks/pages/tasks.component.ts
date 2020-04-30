import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from "@angular/material/dialog";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ConfirmationDialog } from 'src/app/shared/ConfirmationDialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Task } from '../models/tasks';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  showGrid = true;
  formMessage = '';
  isEdit = true;
  public formData: FormGroup;
  taskList: Task[] = [];
  dataSource = new MatTableDataSource(this.taskList);
  displayedColumns: string[] = ['taskSummary', 'taskDescription', 'assignee', 'assignedTo', 'plannedStartDate',
  'plannedEndDate','actualStartDate','actualEndDate','status','priority','progress','createdBy',
  'modifiedBy','createdDateTime','modifiedDateTime','userId'
  ];



  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private http: HttpClient,private dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.getTasks();
  }

  createTask()
    {
        this.formMessage = "Create Task";
        this.showGrid = false;
        this.isEdit = false;

        this.formData = new FormGroup({
            taskId: new FormControl(0, [Validators.required, Validators.maxLength(15)]),
            taskSummary: new FormControl('', [Validators.required, Validators.maxLength(150)]),
            taskDescription: new FormControl('', [Validators.required, Validators.maxLength(150)]),
           // assignee: new FormControl('', [Validators.required, Validators.maxLength(150)]),
            plannedStartDate:new FormControl(),
            plannedEndDate:new FormControl(),
            actualStartDate:new FormControl(),
            actualEndDate:new FormControl(),
            status:new FormControl('',[Validators.required]),
            priority:new FormControl(),
            progress:new FormControl(),
            createdBy:new FormControl(),
            modifiedBy:new FormControl(),
            createdDateTime:new FormControl(),
            modifiedDateTime:new FormControl(),
            userId: new FormControl('',Validators.required)

        });
    }
    showEditOrAdd(dataSelected: Task): void {
      this.formMessage = 'Edit Task';
      this.isEdit = true;
      this.showGrid = false;
      this.formData = new FormGroup({
        taskId: new FormControl(0, [Validators.required, Validators.maxLength(15)]),
        taskSummary: new FormControl('', [Validators.required, Validators.maxLength(150)]),
        taskDescription: new FormControl('', [Validators.required, Validators.maxLength(150)]),
       // assignee: new FormControl('', [Validators.required, Validators.maxLength(150)]),
        plannedStartDate:new FormControl(),
        plannedEndDate:new FormControl(),
        actualStartDate:new FormControl(),
        actualEndDate:new FormControl(),
        status:new FormControl('',[Validators.required]),
        priority:new FormControl(),
        progress:new FormControl(),
        createdBy:new FormControl(),
        modifiedBy:new FormControl(),
        createdDateTime:new FormControl(),
        modifiedDateTime:new FormControl(),
        userId: new FormControl('',Validators.required)

    });
      
  }
    getTasks() {
      this.http.get<Task[]>(environment.apiUrl + '/TaskMaintenances').subscribe(data => {
          this.taskList = data;
          this.reloadTable();

      });
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.formData.controls[controlName].hasError(errorName);
}
onCancel() {
  this.formData.reset();
  this.showGrid = true;
}
reloadTable() {
  this.dataSource = new MatTableDataSource(this.taskList);

}
formSubmit(formvalue) {
  //var user = this.rolesData.filter(x => x.roleId == this.formData.get("roleId").value);
  // var updateUser: User = {
  //     emailAddress: this.formData.get("emailAddress").value,
  //     userId: this.formData.get("userId").value,
  //     userName: this.formData.get("userName").value,
  //     isActive: this.formData.get("isActive").value,
  //     password: this.formData.get("password").value,
  //     role: selectedRole[0],
  //     roleId: this.formData.get("roleId").value,

  // }
  // this.saveUser(updateUser);
}
showDeleteConfirmation(task:Task) {
  const dialogRef = this.dialog.open(ConfirmationDialog,{
    data:{
      message: 'Are you sure want to delete '+task.taskDescription +' ?',
      buttonText: {
        ok: 'Yes',
        cancel: 'No'
      }
    }
  });
  
  dialogRef.afterClosed().subscribe((confirmed: boolean) => {
    if (confirmed) {

      this.http.delete(environment.apiUrl + "TaskMaintenances/"+task.taskId).subscribe(data => {
          // this.snackBar.open('User deleted!', '', {
          //     duration: 2000,
          //   // tslint:disable-next-line:align
          //   });  
           this.showGrid =  true;
          this.getTasks();

      }); 
    }
  });
}

}
