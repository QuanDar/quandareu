import { Url } from "url";
import { IImage } from "../image/image";
import { IWordPressTemplateCategory } from "./wordpress-template-category";

export interface IWordpressTemplate {
    id: number;
    title: string;
    description: string;
    creationDate: string;
    updatedDate: string;
    categories : IWordPressTemplateCategory[]
    imageId: number;
    image: IImage;
    //imagesExtra: IImage[];
}