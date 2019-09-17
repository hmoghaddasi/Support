import { ResponseDetailModel } from 'src/app/response/shared/response-detail.model';

export class RequestDetailModel {
    public requestId: number;
    public requestDate: Date;
    public requestShDate: string;
    public requestById: number;
    public statusId: number;
    public title: string;
    public description: string;
    public requestBy: string;
    public status: string;
    public typeId: number;
    public type: string;
    public priorityId: number;
    public priority: string;
    public assignedId: number;
    public assigned: string;
    public projectId: number;
    public project: string;
    public responses: ResponseDetailModel[];
  }