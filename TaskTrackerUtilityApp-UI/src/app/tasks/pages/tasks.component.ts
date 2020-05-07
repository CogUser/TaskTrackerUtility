import { Component, OnInit, ViewChild } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
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
  styleUrls: ['./tasks.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class TasksComponent implements OnInit {  
  lastTaskId=7;
  editedTaskId:number;
  showGrid = true;  
  formMessage = '';
  isEdit = true;  
  taskList: Task[] = [];
  dataSource = new MatTableDataSource(this.taskList);
  displayedColumns: string[] = ['taskSummary', 'assignedTo','status','priority','progress', 'actions'];
  expandedElement:  Task | null;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private http: HttpClient,private dialog: MatDialog, private snackBar: MatSnackBar) { }  
  
  taskFormData: FormGroup;  

  priorities: any = [
    {value: 'Low', text: 'Low'},
    {value: 'Medium', text: 'Medium'},
    {value: 'High', text: 'High'},
  ]  

  userList: any = [
    {value: 'Ajaynath', text: 'Ajaynath'},
    {value: 'Hema Subramonian', text: 'Hema Subramonian'},
    {value: 'Kamila', text: 'Kamila'},
    {value: 'Nagoor', text: 'Nagoor'},
    {value: 'Ramakrishna', text: 'Ramakrishna'},
    {value: 'Vijay', text: 'Vijay'},
    {value: 'Viswa', text: 'Viswa'},
  ]  

  taskStatusList: any = [
    {value: 'Open', text: 'Open'},
    {value: 'Started', text: 'Started'},
    {value: 'Inprogress', text: 'Inprogress'},
    {value: 'Closed', text: 'Closed'},
  ]   

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.taskList = this.InitialGridData();
    this.getTasks();    
  }

  createTask()
  {          
    this.formMessage = "Create Task";
      this.showGrid = false;
      this.isEdit = false;
      
      this.taskFormData=new FormGroup({
        taskSummary: new FormControl('', Validators.required),
        taskDescription: new FormControl('', Validators.required),
        priority: new FormControl('', Validators.required),
        assignedTo: new FormControl('', Validators.required),
        status: new FormControl('Open', Validators.required),
        taskWatcher: new FormControl(''),
        createdBy: new FormControl(''),
        plannedStartDate: new FormControl(null, Validators.required),
        plannedEndDate: new FormControl(null, Validators.required),
        actualStartDate: new FormControl(null),
        actualEndDate: new FormControl(null),
        progress: new FormControl(),
      });  
  }

  showEditOrAdd(dataSelected: Task): void { 

      this.formMessage = 'Edit Task';
      this.isEdit = true;
      this.showGrid = false;      
      let _progress = (dataSelected.progress=="" || dataSelected.progress == null)?null : parseInt(dataSelected.progress.replace('%',''))

      this.editedTaskId=dataSelected.taskId;
      this.taskFormData=new FormGroup({
        taskSummary: new FormControl(dataSelected.taskSummary, Validators.required),
        taskDescription: new FormControl(dataSelected.taskDescription, Validators.required),
        priority: new FormControl(dataSelected.priority, Validators.required),
        assignedTo: new FormControl(dataSelected.assignedTo, Validators.required),
        status: new FormControl(dataSelected.status, Validators.required),
        taskWatcher: new FormControl(dataSelected.watchers),
        createdBy: new FormControl(dataSelected.createdBy),
        plannedStartDate: new FormControl(dataSelected.plannedStartDate, Validators.required),
        plannedEndDate: new FormControl(dataSelected.plannedEndDate, Validators.required),
        actualStartDate: new FormControl(dataSelected.actualStartDate),
        actualEndDate: new FormControl(dataSelected.actualEndDate),
        progress: new FormControl(_progress),
      });  
  }

  getTasks() {  
    this.reloadTable();
      // this.http.get<Task[]>(environment.apiUrl + '/TaskMaintenances').subscribe(data => {
      //     this.taskList = data;
      //     this.reloadTable();

      // });
  }

onCancel() {
  this.taskFormData.reset();
  this.showGrid = true;
}

reloadTable() {
  this.dataSource = new MatTableDataSource(this.taskList);

}

formSubmit() {
  //make form touched
  Object.keys(this.taskFormData.controls).forEach(field => { 
      const control = this.taskFormData.get(field);           
      control.markAsTouched({ onlySelf: true });       
    });

  // stop here if form is invalid
  if (this.taskFormData.invalid) {
      return;
  }

  //get form data
  let _progress=this.taskFormData.get('progress').value;
  _progress = (_progress=='' || _progress ==null)? "" : _progress + '%';    
    
    var data= {
      taskId: 0, 
      taskSummary: this.taskFormData.get('taskSummary').value, 
      taskDescription: this.taskFormData.get('taskDescription').value,
      assignee: this.taskFormData.get('createdBy').value, 
      assignedTo: this.taskFormData.get('assignedTo').value,
      plannedStartDate: this.taskFormData.get('plannedStartDate').value,
      plannedEndDate: this.taskFormData.get('plannedEndDate').value,
      actualStartDate: this.taskFormData.get('actualStartDate').value,
      actualEndDate: this.taskFormData.get('actualEndDate').value,
      status: this.taskFormData.get('status').value,
      priority: this.taskFormData.get('priority').value, 
      progress: _progress, 
      watchers:this.taskFormData.get('taskWatcher').value, 
      userId:1, 
      createdBy:this.taskFormData.get('createdBy').value, 
      modifiedBy:this.taskFormData.get('createdBy').value
  }   

  //Create screen save
  if(!this.isEdit)
  {
    this.lastTaskId++; 
    data.taskId =this.lastTaskId;  
    this.taskList.push(data); 
    this.snackBar.open('Task Added!', '', {
      duration: 2000,
    });
    //alert("Task Created Successfully");
    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(createdData))     
  }
  else{
    //find no data changed for updated 
    if(!this.taskFormData.dirty)
     {
        this.snackBar.open('No data changed for update', '', {
          duration: 2000,
        });

        return;
     }

    //for edit task save
      data.taskId = this.editedTaskId;
      
      //updated edited data in the existing task list
      let updatedTaskListData = this.taskList.map((task) => {
        if(task.taskId === this.editedTaskId) {
          task.taskSummary = data.taskSummary;
          task.taskDescription = data.taskDescription;
          task.assignee = data.assignee;
          task.assignedTo =data.assignedTo;
          task.plannedStartDate =data.plannedStartDate;
          task.plannedEndDate = data.plannedEndDate;
          task.actualStartDate =data.actualStartDate;
          task.actualEndDate =data.actualEndDate;
          task.status =data.status;
          task.priority =data.priority;
          task.progress =data.progress;
          task.watchers =data.watchers;
          task.createdBy =data.createdBy;
        }
        return task 
      });

      this.taskList=updatedTaskListData;
      this.snackBar.open('Task updated!', '', {
        duration: 2000,
      });
      //alert("Task updated successfully");
  }

  this.onCancel();
  this.getTasks();
}
showDeleteConfirmation(task:Task, index:number) {

  const dialogRef = this.dialog.open(ConfirmationDialog,{
    data:{
      message: 'Are you sure want to delete this task?',
      buttonText: {
        ok: 'Yes',
        cancel: 'No'
      }
    }
  });
  
  dialogRef.afterClosed().subscribe((confirmed: boolean) => {
    if (confirmed) {      
      this.taskList.splice(index, 1);
      this.getTasks();

      this.snackBar.open('Task deleted!', '', {
        duration: 2000,
      });
      // this.http.delete(environment.apiUrl + "TaskMaintenances/"+task.taskId).subscribe(data => {
      //     // this.snackBar.open('User deleted!', '', {
      //     //     duration: 2000,
      //     //   // tslint:disable-next-line:align
      //     //   });  
      //      this.showGrid =  true;
      //     this.getTasks();

      // }); 
    }
  });
}

InitialGridData()
{
      var initialGridData =[
        {
          taskId:1, 
          taskSummary: "Sample Task 1", 
          taskDescription: "This is a sample task 1",
          assignee: "Supriya", 
          assignedTo: "Nagoor",
          plannedStartDate: new Date(),
          plannedEndDate: new Date(),
          actualStartDate: new Date(),
          actualEndDate: new Date(),
          status: "Started",
          priority: "Low", 
          progress: "20%", 
          watchers:"", 
          userId:1, 
          createdBy:"Supiya", 
          modifiedBy:"Nagoor"
      },
      {
        taskId:2, 
        taskSummary: "Sample Task 2", 
        taskDescription: "This is a sample task 2",
        assignee: "Ramakrishna", 
        assignedTo: "Vijay",
        plannedStartDate: new Date(),
        plannedEndDate: new Date(),
        actualStartDate: new Date(),
        actualEndDate: new Date(),
        status: "Closed",
        priority: "Medium", 
        progress: "100%", 
        watchers:"", 
        userId:1, 
        createdBy:"Ramakrishna", 
        modifiedBy:"Vijay"
    },
    {
      taskId:3, 
      taskSummary: "Sample Task 3", 
      taskDescription: "This is a sample task 3",
      assignee: "Hema Subramonian", 
      assignedTo: "Kamila",
      plannedStartDate: new Date(),
      plannedEndDate: new Date(),
      actualStartDate: new Date(),
      actualEndDate: new Date(),
      status: "Started",
      priority: "High", 
      progress: "50%", 
      watchers:"", 
      userId:1, 
      createdBy:"Hema Subramonian", 
      modifiedBy:"Kamila"
    },
    {
      taskId:4, 
      taskSummary: "Sample Task 4", 
      taskDescription: "This is a sample task 4",
      assignee: "Supriya", 
      assignedTo: "Viswa",
      plannedStartDate: new Date(),
      plannedEndDate: new Date(),
      actualStartDate: new Date(),
      actualEndDate: new Date(),
      status: "Closed",
      priority: "Medium", 
      progress: "100%", 
      watchers:"", 
      userId:1, 
      createdBy:"Supiya", 
      modifiedBy:"Viswa"
    },
    {
      taskId:5, 
      taskSummary: "Sample Task 5", 
      taskDescription: "This is a sample task 5",
      assignee: "Supriya", 
      assignedTo: "Nagoor",
      plannedStartDate: new Date(),
      plannedEndDate: new Date(),
      actualStartDate: new Date(),
      actualEndDate: new Date(),
      status: "Started",
      priority: "High", 
      progress: "75%", 
      watchers:"", 
      userId:1, 
      createdBy:"Supiya", 
      modifiedBy:"Nagoor"
    },
    {
      taskId:6, 
      taskSummary: "Sample Task 6", 
      taskDescription: "This is a sample task 6",
      assignee: "Ajaynath", 
      assignedTo: "Vijay",
      plannedStartDate: new Date(),
      plannedEndDate: new Date(),
      actualStartDate: new Date(),
      actualEndDate: new Date(),
      status: "Started",
      priority: "Low", 
      progress: "30%", 
      watchers:"", 
      userId:1, 
      createdBy:"Ajaynath", 
      modifiedBy:"Vijay"
    }];

    return initialGridData;
}

}
