import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpFamilyDetailsComponent } from './emp-family-details.component';

describe('EmpFamilyDetailsComponent', () => {
  let component: EmpFamilyDetailsComponent;
  let fixture: ComponentFixture<EmpFamilyDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ EmpFamilyDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpFamilyDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
