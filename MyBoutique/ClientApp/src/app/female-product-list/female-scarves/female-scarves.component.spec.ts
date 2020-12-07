import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleScarvesComponent } from './female-scarves.component';

describe('FemaleScarvesComponent', () => {
  let component: FemaleScarvesComponent;
  let fixture: ComponentFixture<FemaleScarvesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleScarvesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleScarvesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
