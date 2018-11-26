import { Component, OnInit } from '@angular/core';
import { IPost } from '../../core/http/blog/post';
import { BlogService } from '../../core/http/blog/blog.service';
import { ActivatedRoute } from '@angular/router';
import { IBlog } from '../../core/http/blog/blog';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  private post: IPost;
  private category: string;

  constructor(private _blogService: BlogService, private activeRoute: ActivatedRoute) { 
  }

  ngOnInit() {
    this.category = this._blogService.getCategory();
    this._blogService.getPost(this.activeRoute.snapshot.params.id).subscribe(data => this.post = data);
  }
}
