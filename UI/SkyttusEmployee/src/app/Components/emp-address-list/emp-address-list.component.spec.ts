import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpAddressListComponent } from './emp-address-list.component';

describe('EmpAddressListComponent', () => {
  let component: EmpAddressListComponent;
  let fixture: ComponentFixture<EmpAddressListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ EmpAddressListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpAddressListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
