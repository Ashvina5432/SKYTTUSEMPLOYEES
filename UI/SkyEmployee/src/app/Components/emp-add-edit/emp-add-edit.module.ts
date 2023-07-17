import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule,Routes } from '@angular/router';
import { EmpAddEditComponent } from './emp-add-edit.component';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes=[{
   path:'',
   component:EmpAddEditComponent

}]

@NgModule({
  declarations: [
    EmpAddEditComponent
  ],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)],
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [RouterModule]
})
export class EmpAddEditModule { }
