import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleBlouseComponent } from './female-blouse.component';

describe('FemaleBlouseComponent', () => {
  let component: FemaleBlouseComponent;
  let fixture: ComponentFixture<FemaleBlouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleBlouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleBlouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
