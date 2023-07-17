import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpFamilyDetailsListComponent } from './emp-family-details-list.component';

describe('EmpFamilyDetailsListComponent', () => {
  let component: EmpFamilyDetailsListComponent;
  let fixture: ComponentFixture<EmpFamilyDetailsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ EmpFamilyDetailsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpFamilyDetailsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
