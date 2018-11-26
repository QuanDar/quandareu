import { Component, OnInit } from '@angular/core';
import { IImage } from '../../../core/http/image/image';
import { ImageService } from '../../../core/http/image/image.service';
import { IWordpressTemplate } from '../../../core/http/wordpress-templates/wordpress-template';
import { WordpressTemplateService } from '../../../core/http/wordpress-templates/wordpress-template.service';

@Component({
  selector: 'app-wordpress-templates',
  templateUrl: './wordpress-templates.component.html',
  styleUrls: ['./wordpress-templates.component.css']
})
export class WordpressTemplatesComponent implements OnInit {
  public imageMain: IWordpressTemplate;
  public wordPressTemplates: IWordpressTemplate[];

  constructor(private _wordpressTemplateService: WordpressTemplateService) { }

  ngOnInit() {
    this._wordpressTemplateService.getWPAmount(4).subscribe(data => this.wordPressTemplates = data);
  }
}
