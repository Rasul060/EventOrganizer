export class GetEvent{
    id:number;
    creationTime:string;
    creatorId:string;
    lastModificationTime:string;
    lastModifierId:string;
    name:string;
    type:number;
    date:string;
    startTime:string;
    endTime:string;
    location:string;
    organizerId:number;
    organizerName:string;
}
export class GetEventResponse{
    totalCount:number;
    items:GetEvent[];
}