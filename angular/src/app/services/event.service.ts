import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddEvent} from "../models/event/event-add";
import {UpdateEvent} from "../models/event/event-update";
import {GetEvent,GetEventResponse}  from "../models/event/get-event";
import { HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class EventService {

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


  getEvents():Observable<GetEventResponse>{
    return this.httpClient.get<GetEventResponse>(this.path+"event",this.tokenHeader);
  }

  add(event:AddEvent){
    return this.httpClient.post(this.path + "event",event,this.tokenHeader);
   }

   deleteEvent(id: number): Observable<any> {
     return this.httpClient.delete(`${this.path}event/${id}`,this.tokenHeader);
   }

   updateEvent(id:number,data:UpdateEvent):Observable<UpdateEvent>{
     return this.httpClient.put<UpdateEvent>(`${this.path}event/${id}`, data, this.tokenHeader);
   }
}
