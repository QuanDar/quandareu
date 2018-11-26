import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '../../../../../node_modules/@angular/common/http';
import { Observable } from '../../../../../node_modules/rxjs';
import { IPost } from './post';
import { IBlog } from './blog';
import { IComment } from './comment';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  private httpHeader: HttpHeaders;
  private category: string;

  constructor(private httpClient: HttpClient) { 
    this.httpHeader = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getPosts(): Observable<IPost[]>{
    return this.httpClient.get<IPost[]>('api/blog/post');
  }

  getPost(id:number): Observable<IPost>  {
    return this.httpClient.get<IPost>('api/blog/post/' + id);
  }

  getComment(postId: number): Observable<IComment[]>{
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', 'Bearer ' + authToken);
    console.log(authToken);
    
    return this.httpClient.get<IComment[]>('api/comment/post/' + postId, { headers: headers });  
  }

  getBlogs(): Observable<IBlog[]> {
    return this.httpClient.get<IBlog[]>('api/blog');
  }

  getBlog(id: number): Observable<IBlog> {
    return this.httpClient.get<IBlog>('api/blog/' + id);
  }

  addComment(comment: IComment){
    return this.httpClient.post<IComment>("api/comment", comment).subscribe(newComment => { newComment; return newComment});
  }

  getCategory() : string {
    return this.category;
  }
  setCategory(category: string) {
    this.category = category;
  }
}
