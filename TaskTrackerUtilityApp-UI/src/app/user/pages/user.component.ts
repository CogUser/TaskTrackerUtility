import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({ 
    selector: 'app-user',
    templateUrl: 'user.component.html' ,
    styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit{
    private _usersURL = 'assets/users.json';
    private _rolesURL = 'assets/roles.json';
    gridData :any = [];
    rolesData :any=[];

    constructor(private http: HttpClient) {}
     
    columnDefs = [
        {headerName: 'Id', field: 'id', width:200, hide:true},
        {headerName: 'User Name', field: 'name', width:200},
        {headerName: 'Email Address', field: 'email', width:300},
        {headerName: 'Role',
         field: 'role', 
         width:200,
         editable:true,
         cellEditor:'agSelectCellEditor',
         cellEditorParams: {
             values:[
                'Admin',
                'Developer'
             ],
         },
        },
        {headerName: 'Is Active',
        width: 150,
        cellRenderer: params => {
          return `<input type='checkbox' ${params.value ? 'checked' : ''} />`;
        },
        field: 'isactive'}
      ];
    
      ngOnInit() {
        this.getUsers();
        this.getRoles();
      }
      getUsers()
        {
            this.http.get(this._usersURL).subscribe(data =>{
                this.gridData = data;
            });
        }
        getRoles()
        {
            this.http.get(this._rolesURL).subscribe(data =>{
                console.log(data);
                this.rolesData = data;
            });
        }

}