import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ZoekmachineOptimalisatieComponent } from './zoekmachine-optimalisatie.component';

describe('ZoekmachineOptimalisatieComponent', () => {
  let component: ZoekmachineOptimalisatieComponent;
  let fixture: ComponentFixture<ZoekmachineOptimalisatieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ZoekmachineOptimalisatieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ZoekmachineOptimalisatieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
