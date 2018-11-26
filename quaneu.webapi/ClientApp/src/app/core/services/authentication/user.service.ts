import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BaseService } from './base.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserRegistration } from '../../authentication/UserRegistration';
import { catchError, map } from 'rxjs/operators';
import { ILogin } from '../../authentication/Login';
import { IRegister } from '../../authentication/Register';
import { IToken } from '../../authentication/Token';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
  }

    register(email: string, password: string, firstName: string, lastName: string) {
      let body: IRegister = {
        email: email,
        password: password,
        firstName: firstName,
        lastName: lastName
      }
    return this.http.post("api/account", body);
  }  

   login(login: ILogin) {
    console.log(login);
    return this.http
      .post('api/auth/login', login)
      .pipe(map((res: any) => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      }));
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }
}

