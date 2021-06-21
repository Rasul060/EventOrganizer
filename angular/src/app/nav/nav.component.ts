import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginConformation } from '../auth/loginConformation';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public http:HttpClient,public authService: AuthService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() : void{
    LoginConformation.involvedUser = true;
  }

  get involvedUser(): boolean {
    return LoginConformation.involvedUser;
  }

logout(){
  this.authService.logout().subscribe(data=>{
    LoginConformation.involvedUser = false;
    console.warn(`${this.involvedUser} Header Login`);
    this.router.navigate(['/login']);
  });
}


}
