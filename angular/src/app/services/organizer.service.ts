import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetOrganizer,GetOrganizerResponse } from '../models/organizer/get-organizer';
import { AddOrganizer } from '../models/organizer/organizer-add';
import { UpdateOrganizer } from '../models/organizer/organizer-update';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService {

  constructor(private httpClient:HttpClient) { }
  path="https://localhost:44334/api/app/";

  token=document.cookie.split('; ').find(row=>row
    .startsWith('IdentityToken='))
    .split('=')[1];

    tokenHeader = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + this.token,
    }),
  };

  getOrganizers():Observable<GetOrganizerResponse>{
    return this.httpClient.get<GetOrganizerResponse>(this.path+"organizer",this.tokenHeader);
  }

  add(organizer:AddOrganizer){
   return this.httpClient.post(this.path + "organizer",organizer,this.tokenHeader);
  }

  deleteOrganizer(id: number): Observable<any> {
    return this.httpClient.delete(`${this.path}organizer/${id}`,this.tokenHeader);
  }

  updateOrganizer(id:number,data:UpdateOrganizer):Observable<UpdateOrganizer>{
    return this.httpClient.put<UpdateOrganizer>(`${this.path}organizer/${id}`, data, this.tokenHeader);
  }
}
