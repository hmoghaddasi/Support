import { ResponseDetailModel } from 'src/app/response/shared/response-detail.model';

export class RequestDetailModel {
    public RequestId: number;
    public RequestDate: Date;
    public RequestShDate: string;
    public RequestById: number;
    public StatusId: number;
    public Title: string;
    public Description: string;
    public RequestBy: string;
    public Status: string;
    public TypeId: number;
    public Type: string;
    public PriorityId: number;
    public Priority: string;
    public AssignedId: number;
    public Assigned: string;
    public ProjectId: number;
    public Project: string;
    public responses: ResponseDetailModel[];
  }