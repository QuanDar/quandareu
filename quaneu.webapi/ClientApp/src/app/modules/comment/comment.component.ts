import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IComment } from '../../core/http/blog/comment';
import { BlogService } from '../../core/http/blog/blog.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  private comments: IComment[];
  private commentId: number;
  private isVisible: boolean;
  private htmlToAdd: string;


  constructor(private _commentService: BlogService, private activeRoute: ActivatedRoute) {
  }

  ngOnInit() {
    this._commentService.getComment(this.activeRoute.snapshot.params.id).subscribe(data => this.comments = data);
    this.commentId = 0;
    console.log("IDDDDDDDD" + this.activeRoute.snapshot.params.id);
    this.isVisible = false;
  }

  votePlusButtonClick() {

  }

  voteMinButtonClick() {

  }



  addCommentButtonClick(text: string) {
    let comment: IComment = {
      commentId: 0,
      postId: 1,
      addDate: new Date(),
      commentText: text,
      downVotes: 0,
      upVotes: 0,
      parentCommentId: this.commentId,
      userName: null
    };
    this._commentService.addComment(comment);
    this.comments.push(comment);
  }

  replyButtonClick(id: number) {
    this.commentId = id;
    this.isVisible = true;
  }
  cancelReplyButtonClick() {
    this.isVisible = false;

  }
}
