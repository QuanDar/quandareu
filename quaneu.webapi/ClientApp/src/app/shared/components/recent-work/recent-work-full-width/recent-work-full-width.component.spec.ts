import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentWorkFullWidthComponent } from './recent-work-full-width.component';

describe('RecentWorkFullWidthComponent', () => {
  let component: RecentWorkFullWidthComponent;
  let fixture: ComponentFixture<RecentWorkFullWidthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentWorkFullWidthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentWorkFullWidthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
