import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KidProductListComponent } from './kid-product-list.component';

describe('KidProductListComponent', () => {
  let component: KidProductListComponent;
  let fixture: ComponentFixture<KidProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KidProductListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KidProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
