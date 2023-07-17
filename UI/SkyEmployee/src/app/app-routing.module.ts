import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

{
  path:'addEditEmployee',loadChildren:() =>import('./Components/emp-add-edit/emp-add-edit.module').then((m)=>m.EmpAddEditModule),
},
{
  path:'EmployeeList',loadChildren:() =>import('./Components/employee-list/employee-list.module').then((m)=>m.EmployeeListModule),
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
