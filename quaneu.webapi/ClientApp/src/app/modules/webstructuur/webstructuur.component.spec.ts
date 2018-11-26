import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WebstructuurComponent } from './webstructuur.component';

describe('WebstructuurComponent', () => {
  let component: WebstructuurComponent;
  let fixture: ComponentFixture<WebstructuurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WebstructuurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WebstructuurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
