import { Injectable } from '@angular/core';
import { BaseService } from '../../services/authentication/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService extends BaseService {

  constructor(private httpClient: HttpClient) {
    super();
  }

  getAccountDetails(): Observable<ProfileService> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', `Bearer ${authToken}`);

    return this.httpClient.get<ProfileService>("/dashboard/home", { headers });
  }
}
