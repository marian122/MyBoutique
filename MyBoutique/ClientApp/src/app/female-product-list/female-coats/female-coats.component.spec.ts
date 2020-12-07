import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleCoatsComponent } from './female-coats.component';

describe('FemaleCoatsComponent', () => {
  let component: FemaleCoatsComponent;
  let fixture: ComponentFixture<FemaleCoatsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleCoatsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleCoatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
