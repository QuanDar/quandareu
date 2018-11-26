import { Injectable } from '@angular/core';
import { HttpClient } from '../../../../../node_modules/@angular/common/http';
import { Observable } from '../../../../../node_modules/rxjs';
import { IWork } from './work';

@Injectable({
  providedIn: 'root'
})
export class WorkService {
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<IWork[]>  {
    return this.httpClient.get<IWork[]>('api/work');
  }
}
