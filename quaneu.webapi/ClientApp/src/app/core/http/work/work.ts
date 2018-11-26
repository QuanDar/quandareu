import { IPost } from "../blog/post";
import { IImage } from "../image/image";
import { Url } from "url";

export interface IWork {
    id: number;
    title: string;
    description: string;
    imageId: number;
    url: Url;
    image: IImage;
    Post : null;
}