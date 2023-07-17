import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatRadioModule } from "@angular/material/radio";
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ReactiveFormsModule } from "@angular/forms";
import { MatIconModule } from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from 'src/app/Services/api.service';

@Component({
  selector: 'app-emp-add-edit',
  standalone: true,
  imports: [CommonModule,
  
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatFormFieldModule,
    MatSelectModule,
    ReactiveFormsModule,
    HttpClientModule
    
  ],
  templateUrl: './emp-add-edit.component.html',
  styleUrls: ['./emp-add-edit.component.scss']
})
export class EmpAddEditComponent implements OnInit {
  employeeForm:FormGroup;
  employee: string[ ]=[
    'EmpCode',
    'firstName',
    'middleName',
    'lastName',
    'email',
    'doj',
    'dob',
    'gender',
   ' designation',
    'phone',
   ' mobile',
    'emergencyContactNo',
    'emergencyContactName',
    
  ];

  constructor(private fb: FormBuilder,private _apiService: ApiService,private _dialogRef:MatDialogRef<EmpAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any ) {
    this.employeeForm = this.fb.group({
      empCode: ['', Validators.required],
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      doj:['',Validators.required],
      dob:['',Validators.required],
      gender: ['',Validators.required],
      designation: ['', Validators.required],
      phone: [''],
      mobile: ['', Validators.required ,Validators.pattern('[0-9]{10}')],
      emergencyContactNo: ['', Validators.required],
      emergencyContactName: ['', Validators.required]
    });
  }ngOnInit(): void {
    this.employeeForm.patchValue(this.data);
  }

  onFormSubmit(){
    if(this. employeeForm.valid){
      if (this.data) {
        console.log(this.employeeForm.value)
        this._apiService.updateEmployee(this.data.id, this.employeeForm.value)
          .subscribe({
            next: (result) => {
               alert("FamilyDetail Updated")
              this._dialogRef.close(true)
              //this.toaster.success("Data Updated Successfully")
  
            }
          })
      }
      else {
        console.log(this.employeeForm.value)
        this._apiService.addEmployee(this.employeeForm.value)
          .subscribe({
            next: (res:any) => {
              alert("FamilyDetail Added Successfully")
              this._dialogRef.close(true)
              //this.toaster.success("Data Added Successfully")
  
            }
          })
      }
    }
    
  }
}
