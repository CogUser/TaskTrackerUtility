import { Component, OnInit } from '@angular/core';
import { UserData, Role } from '../models/userData';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';


@Component({
    selector: 'app-user',
    templateUrl: 'user.component.html',
    styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {
    gridData: any = [];
    roles: any = [];
    rolesData: any = [];
    columnDefs: any = [];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.getUsers();
        /*this.getRoles();*/
    }
    getUsers() {
        /* this.http.get(this._usersURL).subscribe(data =>{
            this.gridData = data;
        });*/

        this.userService.getUserData().subscribe((userData: UserData[]) => {
            this.gridData = userData;
            if (this.gridData != null && this.gridData.length > 0) {
                for (let i = 1; i <= 1; i++) {
                    this.roles = userData[0].Role;
                    for (let j = 0; j < this.roles.length; j++) {
                        const role: Role = {
                            RoleId: this.roles[j].RoleId,
                            RoleName: this.roles[j].RoleName
                        }
                        this.rolesData.push(role);
                    }
                }

                this.columnDefs = [
                    { headerName: 'Id', field: 'UserId', width: 200, hide: true },
                    { headerName: 'User Name', field: 'UserName', width: 200 },
                    { headerName: 'Email Address', field: 'EmailAddress', width: 300 },
                    {
                        headerName: 'Role',
                        //field: 'RoleId',
                        field: 'RoleId',
                        width: 200,
                        editable: true,
                        cellEditor: 'agSelectCellEditor',
                        cellEditorParams:this.rolesData
                      /*  cellEditorParams: {
                            values: this.extractValues(this.rolesData)
                        },
                        valueFormatter: function (params) {
                            return this.lookupValue(this.rolesData, params.value);
                        },
                        valueParser: function (params) {
                            return this.lookupKey(this.rolesData, params.newValue);
                        },*/
                    },
                    {
                        headerName: 'Is Active',
                        field: 'IsActive',
                        width: 150,
                        cellRenderer: params => {
                            return `<input type='checkbox' ${params.value ? 'checked' : ''} />`;
                        },
                    }
                ];
            }

        });
    }


    extractValues(mappings) {
        return Object.keys(mappings);
    }
    lookupValue(mappings, key) {
        return mappings[key];
    }
    lookupKey(mappings, name) {
        for (var key in mappings) {
            if (mappings.hasOwnProperty(key)) {
                if (name === mappings[key]) {
                    return key;
                }
            }
        }
    }

    /* getRoles()
     {
           this.http.get(this._rolesURL).subscribe(data =>{
               console.log(data);
               this.rolesData = data;
           });
     }*/

}