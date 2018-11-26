import { Injectable } from "@angular/core";
import { IBlog } from "../http/blog/blog";

@Injectable()
export class CategoryService {
  Category: IBlog;

  constructor() { }

}
