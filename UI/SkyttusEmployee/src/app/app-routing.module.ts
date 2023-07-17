import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'EmpAddEditComponent',loadChildren:() =>import('./Components/emp-add-edit/emp-add-edit.module').then((m)=>m.EmpAddEditModule),
  },
  {
    path:'',loadComponent:()=>import('./Components/employee-list/employee-list.component').then((C)=>C.EmployeeListComponent),
  },
  {
    path:'empaddress',loadComponent:()=>import('./Components/emp-address/emp-address.component').then((C)=>C.EmpAddressComponent),
  },
  {
    path:'addresslist',loadComponent:()=>import('./Components/emp-address-list/emp-address-list.component').then((C)=>C.EmpAddressListComponent),
  },
  {
    path:'empfamilydetail',loadComponent:()=>import('./Components/emp-family-details/emp-family-details.component').then((C)=>C.EmpFamilyDetailsComponent),
  },
  {
    path:'empfamilydetaillist',loadComponent:()=>import('./Components/emp-family-details-list/emp-family-details-list.component').then((C)=>C.EmpFamilyDetailsListComponent),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
