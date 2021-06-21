import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUser } from '../models/loginUser';
import { AuthService } from '../services/auth.service';
import { LoginConformation } from './loginConformation';


@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  loginModel: LoginUser = new LoginUser();
  returnErrorData: [];

  get involvedUser(): boolean {
    return LoginConformation.involvedUser;
  }

  constructor(public authService: AuthService, private router: Router) {
  }

  onSubmit() {
    this.authService.getToken(this.loginModel.password, this.loginModel.username).subscribe(
      data => {
        document.cookie = `IdentityToken=${data.access_token}; expires=${data.expires_in}; Secure;`;
        this.router.navigate(['/book']);
        LoginConformation.involvedUser = true;
        console.warn(`${this.involvedUser} AuthService Login`);
      },
      errorData => {
        // @ts-ignore
        this.returnErrorData = errorData.error.error_description;
        LoginConformation.involvedUser = false;
        console.warn(`${this.involvedUser} AuthService login`);
      });
  }

  ngOnInit(): void {
    LoginConformation.involvedUser = false;
  }

}
