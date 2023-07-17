import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import{MatFormFieldModule} from '@angular/material/form-field';
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator, MatPaginatorModule } from "@angular/material/paginator";
import {MatTableModule  } from "@angular/material/table";
import {MatSort, MatSortModule} from "@angular/material/sort";
import { MatInputModule } from "@angular/material/input";

import { MatDialog, MatDialogModule } from "@angular/material/dialog";
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from "@angular/material/toolbar";
import {MatIconModule  } from "@angular/material/icon";
import {  Router, RouterModule } from '@angular/router';
// import { EmployeeDetailsComponent } from '../employee-details/employee-details.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { ApiService } from 'src/app/Services/api.service';
import { EmpAddEditComponent } from '../emp-add-edit/emp-add-edit.component';
import { DialogRef } from '@angular/cdk/dialog';
import {MatSnackBarModule} from '@angular/material/snack-bar';
@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatToolbarModule,
    MatSortModule,
    MatIconModule,
    MatDialogModule,
    RouterModule,
    MatProgressBarModule,
    MatSnackBarModule
  ],
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent {
  employeeList: any[] = [
    'id',
    'EmpCode',
    'FirstName',
    'MiddleName',
    'LastName',
    'DOJ',
    'DOB',
    'Phone',
    'Mobile',
    'Designation',
    'Gender',
    'EmergencyContactNo',
    'EmergencyContactName',
    'action',
  ];

  // displayedColumns: string[] = ['id', 'name', 'progress', 'fruit'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  

  constructor(private _apiService: ApiService, private router: Router, private dialog:MatDialogModule,
    private _dialog:MatDialog) { }

  ngOnInit() {
    this.EmployeeList();
  }
  openemployee(){
   const dialogRef= this._dialog.open(EmpAddEditComponent)
   dialogRef.afterClosed().subscribe({
    next:(val: any)=>{
      if(val){
        this.EmployeeList();
      }
    }
   })
  }

  EmployeeList() {
    this._apiService.getAllEmployee().subscribe({
      next:(res)=>{
        this.dataSource=new MatTableDataSource(res);
        console.log(res)
        this.dataSource.sort =this.sort;
        this.dataSource.paginator=this.paginator;
      },
      error:console.log
    })
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  deleteEmployee(id: string) {
    this._apiService.delateEmployee(id).subscribe({
      next:(res)=>{
        alert('Employee deleted!');
        this.EmployeeList();
      },
      error:console.log
    });
  }
    
  updateEmployee(data: any){
    const dialogRef= this._dialog.open(EmpAddEditComponent,{
      data:data
     })
  
     dialogRef.afterClosed().subscribe({
      next:(val: any)=>{
        if(val){
          this.EmployeeList();
        }
      }
     })
   }
}

