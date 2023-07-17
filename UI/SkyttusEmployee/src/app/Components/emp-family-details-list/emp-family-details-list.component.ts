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
import { EmpAddressComponent } from '../emp-address/emp-address.component';
import { EmpFamilyDetailsComponent } from '../emp-family-details/emp-family-details.component';


@Component({
  selector: 'app-emp-family-details-list',
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
  templateUrl: './emp-family-details-list.component.html',
  styleUrls: ['./emp-family-details-list.component.scss']
})
export class EmpFamilyDetailsListComponent {
  familyDetails: any[] = [
    'id',
    'employeeId',
    'firstName',
    'middleName',
    'lastName',
    'dob',
    'gender',
    'relationId',
    'action',
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _apiService: ApiService, private router: Router, private dialog:MatDialogModule,
    private _dialog:MatDialog) { }

    ngOnInit() {
      this.FamilyDetailsList();
    }
    
    openFamilyDetails(){
      const dialogRef= this._dialog.open(EmpFamilyDetailsComponent)
      dialogRef.afterClosed().subscribe({
       next:(val: any)=>{
         if(val){
           this.FamilyDetailsList();
         }
       }
      })
     }
   
     FamilyDetailsList() {
      this._apiService.getAllFamilyDetails().subscribe({
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
    delateFamilyDetails(id: string) {
      this._apiService.delateFamilyDetails(id).subscribe({
        next:(res)=>{
          alert('Address deleted!');
          this.FamilyDetailsList();
        },
        error:console.log
      });
    }
    updateFamilyDetails(data: any){
      const dialogRef= this._dialog.open(EmpFamilyDetailsComponent,{
        data:data
       })
    
       dialogRef.afterClosed().subscribe({
        next:(val: any)=>{
          if(val){
            this.FamilyDetailsList();
          }
        }
       })
     }
}
