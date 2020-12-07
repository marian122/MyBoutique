import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleUnionsuitComponent } from './female-unionsuit.component';

describe('FemaleUnionsuitComponent', () => {
  let component: FemaleUnionsuitComponent;
  let fixture: ComponentFixture<FemaleUnionsuitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleUnionsuitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleUnionsuitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
