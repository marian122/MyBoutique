import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemalePantsComponent } from './female-pants.component';

describe('FemalePantsComponent', () => {
  let component: FemalePantsComponent;
  let fixture: ComponentFixture<FemalePantsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemalePantsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemalePantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
