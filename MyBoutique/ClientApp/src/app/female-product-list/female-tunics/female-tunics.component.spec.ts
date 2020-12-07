import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleTunicsComponent } from './female-tunics.component';

describe('FemaleTunicsComponent', () => {
  let component: FemaleTunicsComponent;
  let fixture: ComponentFixture<FemaleTunicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FemaleTunicsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleTunicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
