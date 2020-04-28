
export interface UserData {
    UserId: number,
    UserName:string,
    EmailAddress:string,
    IsActive:boolean,
    RoleId:number,
    Role:Role

}
export interface Role {
    RoleId: number,
    RoleName:string
}
        