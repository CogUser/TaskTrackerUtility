export class User {
    userId: number;
    userName: string;
    emailAddress: string;
    isActive: boolean;
    role?: Role;
    password?: string;
    roleId: number
}
export class Role {

    roleId: string;
    roleName: string;
    isActive: boolean
}