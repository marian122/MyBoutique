import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleShirtComponent } from './female-shirt.component';

describe('FemaleShirtComponent', () => {
  let component: FemaleShirtComponent;
  let fixture: ComponentFixture<FemaleShirtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleShirtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleShirtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
