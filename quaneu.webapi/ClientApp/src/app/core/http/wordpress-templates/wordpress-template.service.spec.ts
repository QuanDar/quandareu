import { TestBed, inject } from '@angular/core/testing';

import { WordpressTemplateService } from './wordpress-template.service';

describe('WordpressTemplateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WordpressTemplateService]
    });
  });

  it('should be created', inject([WordpressTemplateService], (service: WordpressTemplateService) => {
    expect(service).toBeTruthy();
  }));
});
