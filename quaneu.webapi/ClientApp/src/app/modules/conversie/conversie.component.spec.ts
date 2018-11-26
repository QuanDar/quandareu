import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConversieComponent } from './conversie.component';

describe('ConversieComponent', () => {
  let component: ConversieComponent;
  let fixture: ComponentFixture<ConversieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConversieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConversieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
