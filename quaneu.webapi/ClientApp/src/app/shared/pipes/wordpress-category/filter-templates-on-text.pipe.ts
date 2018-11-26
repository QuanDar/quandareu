import { Pipe, PipeTransform } from '@angular/core';
import { IWordpressTemplate } from '../../../core/http/wordpress-templates/wordpress-template';

@Pipe({
  name: 'filterTemplatesOnText'
})
export class FilterTemplatesOnTextPipe implements PipeTransform {
  transform(items: IWordpressTemplate[], searchText: string): IWordpressTemplate[] {
    if (!items) return [];
    if (!searchText) return items;

    return items.filter(it => {
      var searched = it.title.toLowerCase().includes(searchText.toLowerCase());
      if (searched != null){
        return searched
      }

      searched = it.description.toLowerCase().includes(searchText.toLowerCase());
      return searched;
    });
  }
}
