import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IImage } from './image';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private httpClient: HttpClient) { }

  getImage(id: number) : Observable<IImage>  {
    return this.httpClient.get<IImage>('api/image/${id}');
  }

  getImageAmount(amount: number) : Observable<IImage[]>  {
    return this.httpClient.get<IImage[]>('api/amount/${amount}');
  }

  getImages() : Observable<IImage[]> {
    return this.httpClient.get<IImage[]>("api/image");
  }
}
