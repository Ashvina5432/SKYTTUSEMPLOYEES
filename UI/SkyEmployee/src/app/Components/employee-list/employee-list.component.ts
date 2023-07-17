import { Component, OnInit,ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/Services/api.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  employeeList: any[] = [
    'id',
    'EmpCode',
    'FirstName',
    'LastName',
    'DOJ',
    'Mobile',
    'Designation',
    'Gender',
    'EmergencyContactNo',
    'Address',
    'AddressTypeId',
    'City',
    'State',
    'Country',
    'RelationId',
    'action',
  ];

  // displayedColumns: string[] = ['id', 'name', 'progress', 'fruit'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _apiService: ApiService, private router: Router) { }

  ngOnInit() {
    this.EmployeeList();
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
 
}
 
