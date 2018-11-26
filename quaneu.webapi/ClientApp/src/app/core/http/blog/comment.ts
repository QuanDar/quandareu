export interface IComment {
    commentId: number;
    postId: number;
    userName: string;
    addDate: Date;
    commentText: string;
    upVotes: number;
    downVotes: number;
    parentCommentId: number;
}