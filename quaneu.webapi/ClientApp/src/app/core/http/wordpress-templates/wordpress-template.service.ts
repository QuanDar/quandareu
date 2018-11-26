import { Injectable } from '@angular/core';
import { HttpClient } from '../../../../../node_modules/@angular/common/http';
import { IWordpressTemplate } from './wordpress-template';
import { Observable } from '../../../../../node_modules/rxjs';
import { IWordPressTemplateCategory } from './wordpress-template-category';

@Injectable({
  providedIn: 'root'
})
export class WordpressTemplateService {
  constructor(private httpClient: HttpClient) { }

  getWPTemplates(): Observable<IWordpressTemplate[]>  {
    return this.httpClient.get<IWordpressTemplate[]>('api/WordPressTemplate');
  }

  getWPTemplate(id: number): Observable<IWordpressTemplate>  {
    return this.httpClient.get<IWordpressTemplate>('api/WordPressTemplate/' + id);
  }

  getWPAmount(amount: number) : Observable<IWordpressTemplate[]>  {
    return this.httpClient.get<IWordpressTemplate[]>('api/WordPressTemplate/amount/' + amount);
  }

  getWPCategories() : Observable<IWordPressTemplateCategory[]> {
    return this.httpClient.get<IWordPressTemplateCategory[]>('api/WordPressTemplate/categories');
  }
}
