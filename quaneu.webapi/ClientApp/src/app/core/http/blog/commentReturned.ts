export interface ICommentReturned {
    commentId: number;
    postId: number;
    user: string;
    addDate: Date;
    commentText: string;
    upVotes: number;
    downVotes: number;
    parentCommentId: number;
}