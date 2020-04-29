import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User, Role } from './user';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from "@angular/material/dialog";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ConfirmationDialog } from 'src/app/shared/ConfirmationDialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-user',
    templateUrl: 'user.component.html',
    styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {
    showGrid = true
    gridData: any = [];
    isEdit = true;
    rolesData: Role[] = [];
    userList: User[] = []
    formMessage = ''
    dataSource = new MatTableDataSource(this.userList);
    displayedColumns: string[] = ['userName', 'emailAddress', 'role', 'isActive', 'Actions'];
    public formData: FormGroup;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    constructor(private http: HttpClient, private dialog: MatDialog,private snackBar: MatSnackBar) {
    }


    ngOnInit() {
        this.dataSource.sort = this.sort;

        this.getRoles();
    }
    getRoles() {

        this.http.get<Role[]>(environment.apiUrl + '/Role').subscribe(data => {
            this.rolesData = data;
            this.getUsers();

        });

    }

    getUsers() {
        this.http.get<User[]>(environment.apiUrl + '/User').subscribe(data => {
            this.userList = data;
            this.reloadTable();

        });
    }

    reloadTable() {
        this.dataSource = new MatTableDataSource(this.userList);

    }

    showEditOrAdd(dataSelected: User): void {
        this.formMessage = 'Edit User';
        this.isEdit = true;
        this.showGrid = false;
        this.formData = new FormGroup({
            userName: new FormControl(dataSelected.userName, [Validators.required, Validators.maxLength(15)]),
            userId: new FormControl(dataSelected.userId, [Validators.required, Validators.maxLength(15)]),
            password: new FormControl(dataSelected.password,[Validators.required, Validators.maxLength(15),Validators.minLength(5)]),
            emailAddress: new FormControl(dataSelected.emailAddress, [Validators.required, Validators.email]),
            isActive: new FormControl(dataSelected.isActive),
            roleId: new FormControl(dataSelected.roleId,Validators.required)

        });
    }
    addNewUser()
    {
        this.formMessage = "Add User";
        this.showGrid = false;
        this.isEdit = false;

        this.formData = new FormGroup({
            userName: new FormControl('', [Validators.required, Validators.maxLength(15)]),
            userId: new FormControl(0, [Validators.required, Validators.maxLength(15)]),
            password: new FormControl('',[Validators.required, Validators.maxLength(15),Validators.minLength(5)]),
            emailAddress: new FormControl('', [Validators.required, Validators.email]),
            isActive: new FormControl(true),
            roleId: new FormControl('',Validators.required)

        });
    }
    formSubmit(formvalue) {
        var selectedRole = this.rolesData.filter(x => x.roleId == this.formData.get("roleId").value);
        var updateUser: User = {
            emailAddress: this.formData.get("emailAddress").value,
            userId: this.formData.get("userId").value,
            userName: this.formData.get("userName").value,
            isActive: this.formData.get("isActive").value,
            password: this.formData.get("password").value,
            role: selectedRole[0],
            roleId: this.formData.get("roleId").value,

        }
        this.saveUser(updateUser);
    }
    saveUser(updatedUser: User)
    {
        if(updatedUser.userId == 0)
        {
        this.http.post(environment.apiUrl + "User",updatedUser).subscribe(data => {
            this.snackBar.open('New User Added!', '', {
                duration: 2000,
              });
            this.showGrid =  true;
            this.getUsers();

        });
    }
    else
    {
        this.http.put(environment.apiUrl + "User/"+updatedUser.userId,updatedUser).subscribe(data => {
            this.snackBar.open('User updated!', '', {
                duration: 2000,
              });            this.showGrid =  true;
            this.getUsers();

        }); 
    }
    }


    public hasError = (controlName: string, errorName: string) => {
        return this.formData.controls[controlName].hasError(errorName);
    }
    onCancel() {
        this.formData.reset();
        this.showGrid = true;
    }
    showDeleteConfirmation(userToDelete:User) {
        const dialogRef = this.dialog.open(ConfirmationDialog,{
          data:{
            message: 'Are you sure want to delete '+userToDelete.userName +' ?',
            buttonText: {
              ok: 'Yes',
              cancel: 'No'
            }
          }
        });
        
        dialogRef.afterClosed().subscribe((confirmed: boolean) => {
          if (confirmed) {

            this.http.delete(environment.apiUrl + "User/"+userToDelete.userId).subscribe(data => {
                this.snackBar.open('User deleted!', '', {
                    duration: 2000,
                  // tslint:disable-next-line:align
                  });            this.showGrid =  true;
                this.getUsers();

            }); 
          }
        });
      }

}

