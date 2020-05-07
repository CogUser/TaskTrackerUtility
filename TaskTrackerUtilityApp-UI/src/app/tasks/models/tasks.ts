import {User} from '../../user/pages/user';

export class Task {
    taskId: number;
    taskSummary: string;
    taskDescription: string;
    assignee: string;
    assignedTo: string;
    plannedStartDate: Date;
    plannedEndDate: Date;
    actualStartDate: Date;
    actualEndDate: Date;
    status: string;
    priority: string;
    progress: string;
    watchers: string;
    userId: number;
    createdBy: string;
    modifiedBy: string;
}

