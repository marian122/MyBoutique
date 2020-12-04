import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleProductListComponent } from './female-product-list.component';

describe('FemaleProductListComponent', () => {
  let component: FemaleProductListComponent;
  let fixture: ComponentFixture<FemaleProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleProductListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
