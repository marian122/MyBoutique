import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleSingletsComponent } from './female-singlets.component';

describe('FemaleSingletsComponent', () => {
  let component: FemaleSingletsComponent;
  let fixture: ComponentFixture<FemaleSingletsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleSingletsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleSingletsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
