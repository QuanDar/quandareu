import { Url } from "url";

export interface IImage {
    id: number;
    name: string;
    url: Url;
    contentType: string;
    height: number;
    width: number;
}