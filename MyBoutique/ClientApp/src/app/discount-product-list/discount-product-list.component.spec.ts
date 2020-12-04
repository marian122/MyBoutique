import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscountProductListComponent } from './discount-product-list.component';

describe('DiscountProductListComponent', () => {
  let component: DiscountProductListComponent;
  let fixture: ComponentFixture<DiscountProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiscountProductListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscountProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
