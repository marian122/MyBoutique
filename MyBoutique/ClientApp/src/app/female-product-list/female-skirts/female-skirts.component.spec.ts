import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleSkirtsComponent } from './female-skirts.component';

describe('FemaleSkirtsComponent', () => {
  let component: FemaleSkirtsComponent;
  let fixture: ComponentFixture<FemaleSkirtsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleSkirtsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleSkirtsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
