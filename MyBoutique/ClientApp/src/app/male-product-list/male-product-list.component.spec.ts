import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaleProductListComponent } from './male-product-list.component';

describe('MaleProductListComponent', () => {
  let component: MaleProductListComponent;
  let fixture: ComponentFixture<MaleProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaleProductListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaleProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
