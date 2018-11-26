import { Component, OnInit } from '@angular/core';
import { WpTemplCatPipe } from '../../shared/pipes/wordpress-category/wp-templ-cat.pipe';
import { BlogService } from '../../core/http/blog/blog.service';
import { IPost } from '../../core/http/blog/post';
import { IBlog } from '../../core/http/blog/blog';
import { CategoryService } from '../../core/services/categoryService';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  private posts: IPost[];
  private postsFiltered: IPost[];
  private blogs: IBlog[];
  private lastEvent;
  private activeCategoryClick: number = -1;
  private allButton = true;

  constructor(private _blogService: BlogService) {
  }

  ngOnInit() {
    this._blogService.getPosts().subscribe(data => {
      this.posts = data;
      this.postsFiltered = data;
    });
    this._blogService.getBlogs().subscribe(data => this.blogs = data);
    // sets default blog category in breadcrumb for post
    this._blogService.setCategory("Alles");
  }

  filterPosts(event) {

    this.posts = this.posts;
    const categorySearcher = new WpTemplCatPipe();
    this.postsFiltered = categorySearcher.transform(this.posts, "undifined", event.srcElement.innerText);
  }

  allCategoryButtonClick() {
    this.postsFiltered = this.posts;
    this.allButton = true;
    this.activeCategoryClick = -1;
    this._blogService.setCategory("Alles");
  }

  setActiveCategoryClick(i, event) {
    this.activeCategoryClick = i;
    this.allButton = false;
    this._blogService.setCategory(event.target.innerText);
  }
}
