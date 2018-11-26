import { Component, OnInit } from '@angular/core';
import { IWordpressTemplate } from '../../core/http/wordpress-templates/wordpress-template';
import { WordpressTemplateService } from '../../core/http/wordpress-templates/wordpress-template.service';
import { IWordPressTemplateCategory } from '../../core/http/wordpress-templates/wordpress-template-category';

@Component({
  selector: 'app-wordpress',
  templateUrl: './wordpress.component.html',
  styleUrls: ['./wordpress.component.css']
})
export class WordpressComponent implements OnInit {

  public wordPressTemplates: IWordpressTemplate[];
  public bestWPTemplates : IWordpressTemplate[];
  public wordPressCategories : IWordPressTemplateCategory[];

  constructor(private _wordpressTemplateService: WordpressTemplateService) { }

  ngOnInit() {
    this._wordpressTemplateService.getWPTemplates().subscribe(data => this.wordPressTemplates = data);
    this._wordpressTemplateService.getWPCategories().subscribe(data => this.wordPressCategories = data);
  }
  
}
