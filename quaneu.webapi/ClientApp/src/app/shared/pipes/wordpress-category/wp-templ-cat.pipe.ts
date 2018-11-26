import { Pipe, PipeTransform } from '@angular/core';
import { IWordpressTemplate } from '../../../core/http/wordpress-templates/wordpress-template';

@Pipe({
  name: 'wpTemplCat'
})
export class WpTemplCatPipe implements PipeTransform {
  transform(items: any[], searchText: string, searchCat: string): any[] {
    if (!items) return [];
    if (!searchText) return items;

    return items.filter(it => {
      if (searchCat != undefined){
        var searched = it.categories.find(t => t.category.toLowerCase() == searchCat.toLowerCase());
        if (searched) {
          return searched
        }
      }

      var searched2 = it.description.toLowerCase().includes(searchText.toLowerCase());
      if (searched2) {
        return searched2
      }

      searched2 = it.title.toLowerCase().includes(searchText.toLowerCase());
      if (searched2) {
        return searched2
      }
    });
  }
}
