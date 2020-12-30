import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginRequestModel } from '../Share/Model/login-request-model';
import { UserServicesService } from '../Share/Provider/user-services.service';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private readonly loginService: UserServicesService,
 
  ) { }

  ngOnInit(): void {
  }
  Login(loginfrm: NgForm) {
    var login = new LoginRequestModel();
    login.userName = loginfrm.value.userName;
    login.password = loginfrm.value.password;
    this.loginService.login(login);
  }
}
