import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgModel, NgForm } from '@angular/forms';
import { IMail } from '../../core/http/email/email';
import { MailService } from '../../core/http/email/email.service';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  private lat: number = 50.938206;
  private lng: number = 5.348064;

  private submitted = false;
  private contactForm: FormGroup;
  private emailAddress: NgModel;

  private model: any = {};
  private mail: IMail;
  private validEmail: boolean = false;
  private edited = false;
  private result: any;

  constructor(private _emailService: MailService, private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.contactForm = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      emailAddress: ['', [Validators.required, Validators.email]],
      localCommunity: [''],
      zipCode: [''],
      subject: ['', Validators.required],
      body: ['', [Validators.required]]
    });
  }
  onSubmit(contactForm: NgForm) {
    if (contactForm.valid ) {
      this.mail = {
        firstName: this.model.firstName,
        lastName: this.model.lastName,
        localCommunity: this.model.localCommunity,
        zipCode: this.model.zipCode,
        subject: this.model.subject,
        body: this.model.body,
        From: this.model.emailAddress
      };
      this._emailService.sendMail(this.mail).subscribe(text => this.result = text);
      console.log(this.result);
      this.edited = true;
    }
  }
}
