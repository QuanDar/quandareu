import { Url } from "url";
import { IImage } from "../image/image";
import { IComment } from "./comment";
import { IBlog } from "./blog";

export interface IPost {
    id: number;
    title: string;
    description: string;
    url: Url;
    controller: string;
    action: string;
    content: string;
    metaKeywords: string;
    metaDescription: string;
    creationDate: Date;
    updateDate: Date;
    isCommented: boolean;
    isShared: boolean;
    isPrivate: boolean;
    numberOfViews: number;
    image: IImage;
    imageId: number;
    numberOfLikes: number;
    numberOfComments: number;
    numberOfDislikes: number;
    comment: IComment;
    categories: IBlog;
}