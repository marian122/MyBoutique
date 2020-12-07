import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleUnderwearComponent } from './female-underwear.component';

describe('FemaleUnderwearComponent', () => {
  let component: FemaleUnderwearComponent;
  let fixture: ComponentFixture<FemaleUnderwearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleUnderwearComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleUnderwearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
