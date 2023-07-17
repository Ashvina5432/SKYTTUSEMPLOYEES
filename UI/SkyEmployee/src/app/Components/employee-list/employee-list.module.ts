import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmpAddEditComponent } from '../emp-add-edit/emp-add-edit.component';
import { EmployeeListComponent } from './employee-list.component';
import {MatTableModule} from '@angular/material/table';
import {  MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
const routes: Routes=[{
  path:'',
  component:EmployeeListComponent,

}]

@NgModule({
  declarations: [EmployeeListComponent],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)],
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatIconModule,
  ],
  exports: [RouterModule]
})
export class EmployeeListModule { }
