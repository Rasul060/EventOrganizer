export class GetOrganizer{
    id:number;
    name:string;
    birthDate:string;
    shortBio:string;
}
export class GetOrganizerResponse{
    totalCount:number;
    items:GetOrganizer[];
}