import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from "@angular/router";
import { Observable } from 'rxjs';
import { tokenModel } from '../models/tokenModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
   token=document.cookie.split(';').find(row=>row
    .startsWith('IdentityToken='))
    .split('=')[1];

    tokenHeader = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.token,
      }),
    };

    path='https://localhost:44334';

  constructor(private httpClient: HttpClient) { }

  getToken(password:string, username:string): Observable<tokenModel>{
    const body = new HttpParams()
    .set('client_id', 'EventOrganizer_App')
    .set('grant_type', 'password')
    .set('username',username)
    .set('password',password)
    .set('scope', 'EventOrganizer');
    return this.httpClient.post<tokenModel>(`${this.path}/connect/token`,body,{headers:{'Content-Type': 'application/x-www-form-urlencoded'}});
  }

  logout():Observable<tokenModel>{
    return this.httpClient.get<tokenModel>(`${this.path}/api/account/logout`, {headers:{'Content-Type': 'application/x-www-form-urlencoded'}});
  }

}
