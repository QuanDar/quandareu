import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder }
  from '@angular/forms';

@Component({
  selector: 'app-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.css']
})

// Reactive form
export class NewsletterComponent {
  newsetterForm: FormGroup;
  submitted = false;

  constructor(fb: FormBuilder) {
    this.newsetterForm = fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  get f() { return this.newsetterForm.controls; }

  onSubmit() {
    console.log("newsletter form submitted");
    console.log(this.newsetterForm);

    this.submitted = true;

    // stop here if form is invalid
    if (this.newsetterForm.invalid) {
      return;
    }

    alert('SUCCESS!! :-)\n\nIt is working but not doing anything' + JSON.stringify(this.newsetterForm.value.email))
  }
}
