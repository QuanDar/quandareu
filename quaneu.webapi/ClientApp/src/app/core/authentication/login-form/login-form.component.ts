import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { UserService } from '../../services/authentication/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ICredentials } from '../Credentials';
import { finalize } from 'rxjs/operators';
import { ILogin } from '../Login';
import { IToken } from '../Token';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit, OnDestroy {

  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: ICredentials = { email: '', password: '' };

  constructor(private userService: UserService, private router: Router,private activatedRoute: ActivatedRoute) { }

    ngOnInit() {

    // subscribe to router event
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
         this.brandNew = param['brandNew'];   
         this.credentials.email = param['email'];         
      });      
  }

   ngOnDestroy() {
    // prevent memory leak by unsubscribing
    this.subscription.unsubscribe();
  }

  login({ value, valid }: { value: ICredentials, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
    if (valid) {
      let login: ILogin =
      {  
        userName: value.email,
        password: value.password
      };
      this.userService.login(login)
      //.pipe(finalize(() => this.isRequesting = false))
        .subscribe(
        //result => 
        //{         
          //if (result) {
          //   this.router.navigate(['/']);             
          //}
        //},
        //error => this.errors = error
      );
    }
  }
}
