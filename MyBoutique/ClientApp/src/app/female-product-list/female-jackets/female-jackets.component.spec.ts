import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleJacketsComponent } from './female-jackets.component';

describe('FemaleJacketsComponent', () => {
  let component: FemaleJacketsComponent;
  let fixture: ComponentFixture<FemaleJacketsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleJacketsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleJacketsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
