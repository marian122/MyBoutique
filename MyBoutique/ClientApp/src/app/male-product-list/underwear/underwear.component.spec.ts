import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnderwearComponent } from './underwear.component';

describe('UnderwearComponent', () => {
  let component: UnderwearComponent;
  let fixture: ComponentFixture<UnderwearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnderwearComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UnderwearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
