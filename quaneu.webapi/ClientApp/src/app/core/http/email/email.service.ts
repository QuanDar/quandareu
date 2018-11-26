import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { IMail } from './email';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MailService {
  private headers: HttpHeaders;


  constructor(private httpClient: HttpClient) { 
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }
  
  sendMail(email: IMail){
    return this.httpClient.post('api/mail', email);
  }
}
