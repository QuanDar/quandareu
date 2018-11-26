import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WordpressTemplatesComponent } from './wordpress-templates.component';

describe('WordpressTemplatesComponent', () => {
  let component: WordpressTemplatesComponent;
  let fixture: ComponentFixture<WordpressTemplatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WordpressTemplatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WordpressTemplatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
