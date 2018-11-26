import { Component, OnInit } from '@angular/core';
import { IWordpressTemplate } from '../../core/http/wordpress-templates/wordpress-template';
import { IWordPressTemplateCategory } from '../../core/http/wordpress-templates/wordpress-template-category';
import { WordpressTemplateService } from '../../core/http/wordpress-templates/wordpress-template.service';
import { WpTemplCatPipe } from '../../shared/pipes/wordpress-category/wp-templ-cat.pipe'
import { IImage } from '../../core/http/image/image';

@Component({
  selector: 'app-themes',
  templateUrl: './themes.component.html',
  styleUrls: ['./themes.component.css']
})
export class ThemesComponent implements OnInit {

  private wordPressTemplates: IWordpressTemplate[];
  private bestWPTemplates: IWordpressTemplate[];
  private wordPressCategories: IWordPressTemplateCategory[];
  private wordPressTemplatesFiltered: IWordpressTemplate[];
  private wordpressTemplateOne: IWordpressTemplate;
  private wordpressTemplateTwo: IWordpressTemplate;
  private wordpressTemplateThree: IWordpressTemplate;
  private wordpressTemplateFour: IWordpressTemplate;
  private wordpressTemplateFive: IWordpressTemplate;

  private activeCategoryClick: number = -1;
  private allButton = true;
  private elseButton = false;

  constructor(private _wordpressTemplateService: WordpressTemplateService) { }

  ngOnInit() {
    this._wordpressTemplateService.getWPTemplates().subscribe(data => {
      this.wordPressTemplates = data;
      this.wordPressTemplatesFiltered = data;
    });
    this._wordpressTemplateService.getWPCategories().subscribe(data => this.wordPressCategories = data);
    this._wordpressTemplateService.getWPTemplate(1).subscribe(data => this.wordpressTemplateOne = data);
    this._wordpressTemplateService.getWPTemplate(2).subscribe(data => this.wordpressTemplateTwo = data);
    this._wordpressTemplateService.getWPTemplate(3).subscribe(data => this.wordpressTemplateThree = data);
    this._wordpressTemplateService.getWPTemplate(4).subscribe(data => this.wordpressTemplateFour = data);
    this._wordpressTemplateService.getWPTemplate(5).subscribe(data => this.wordpressTemplateFive = data);

  }

  filterTemplates(event) {
    this.wordPressTemplates = this.wordPressTemplates;
    const categorySearcher = new WpTemplCatPipe();
    this.wordPressTemplatesFiltered = categorySearcher.transform(this.wordPressTemplates, "undifined", event.srcElement.innerText);
  }

  allCategoryButton(event) {
    this.wordPressTemplatesFiltered = this.wordPressTemplates;
  }

  setActiveCategoryClick(event, i) {
    this.activeCategoryClick = i;
    this.allButton = false;
    this.elseButton = false;
  }

  allCategoryButtonClick() {
    this.activeCategoryClick = -1;
    this.elseButton = false;
    this.allButton = true;
  }

  elseCategoryButtonClick() {
    this.activeCategoryClick = -1;
    this.allButton = false;
    this.elseButton = true;
  }
}
