import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactPageCoffeeHeroComponent } from './contact-page-coffee-hero.component';

describe('ContactPageCoffeeHeroComponent', () => {
  let component: ContactPageCoffeeHeroComponent;
  let fixture: ComponentFixture<ContactPageCoffeeHeroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContactPageCoffeeHeroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactPageCoffeeHeroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
