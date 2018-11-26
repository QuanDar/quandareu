import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/authentication/user.service';
import { UserRegistration } from '../UserRegistration';
import { finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.register(value.email, value.password, value.firstName, value.lastName).subscribe();
      //.pipe(finalize(() => this.isRequesting = false))
        //.subscribe(
       //   result => {
         //   if (result) {
         //     this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
         //   }
         // },
        //  errors => this.errors = errors);
    }
  }
}
