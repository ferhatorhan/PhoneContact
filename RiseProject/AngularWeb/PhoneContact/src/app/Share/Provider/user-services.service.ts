import { Inject, Injectable } from '@angular/core';
import { inject } from '@angular/core/testing';
import { LoginRequestModel } from '../Model/login-request-model';
import { LoginResponse } from '../Model/login-response';
import { UserRequestModel } from '../Model/user-request-model';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class UserServicesService {

  constructor(@Inject("apiUrl") private readonly apiUrl, private readonly http: HttpClient, public router: Router) { }
  // Sign-in
  login(user: LoginRequestModel) {

    const url: string = this.apiUrl + "/token";
    const header = new Headers();

    header.append(
      "content-type",
      "application/x-www-form-urlencoded; charset=utf-8"
    );

    const tokendata =
      "grant_type=password&username=" + user.userName + "&password=" + user.password;
    const headers = new HttpHeaders().set("content-type", "application/x-www-form-urlencoded; charset=utf-8");
    return this.http.post<LoginResponse>(url, tokendata, { headers })
      .subscribe((res: any) => {
        localStorage.setItem('accessToken', res.access_token);
        localStorage.setItem("token_type", res.token_type);
        this.router.navigate(['/start']);

      })
  }

  getToken() {
    return localStorage.getItem('accessToken');
  }

  logout() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem("token_type");
    this.router.navigate(['/login']);

  }

  isLoggedIn(): boolean {
    let authToken = localStorage.getItem('accessToken');
    return (authToken !== null) ? true : false;
  }




  // Error 
  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {

      msg = error.error.message;
    } else {

      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
}