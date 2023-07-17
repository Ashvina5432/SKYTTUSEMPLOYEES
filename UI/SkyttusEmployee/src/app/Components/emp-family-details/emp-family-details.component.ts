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
  selector: 'app-emp-family-details',
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
  templateUrl: './emp-family-details.component.html',
  styleUrls: ['./emp-family-details.component.scss']
})
export class EmpFamilyDetailsComponent implements OnInit {
  employees: any[] = [];
  relations: any[]=[];
  FamilyDetailForm:FormGroup;
  familyDetais: string[ ]=[
    
    'employeeId',
    'firstName',
    'middleName',
    'lastName',
    'dob',
    'gender',
    'relationId',
    'action',
    
    
  ];
  toaster: any;
  constructor(private fb: FormBuilder,private _apiService: ApiService,private _dialogRef:MatDialogRef<EmpFamilyDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any ) {
    this. FamilyDetailForm = this.fb.group({
     
      employeeId: ['',Validators.required],
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      dob:['',Validators.required],
      gender: ['', Validators.required],
      relationId: ['', Validators.required],

    });
  }
  ngOnInit(): void {
    this. FamilyDetailForm.patchValue(this.data);
    this._apiService.getAllEmployee().subscribe({
      next:(res)=>{
        this.employees = res;
      }
    }),
   
    this._apiService.GetAllRelation().subscribe({
      next:(res)=>{
        this.relations=res;
      }
    })
  }
  onFormSubmit(){
    if(this. FamilyDetailForm.valid){
      if (this.data) {
        console.log(this.FamilyDetailForm.value)
        this._apiService.updateFamilyDetails(this.data.id, this.FamilyDetailForm.value)
          .subscribe({
            next: (result) => {
               alert("FamilyDetail Updated")
              this._dialogRef.close(true)
              //this.toaster.success("Data Updated Successfully")
  
            }
          })
      }
      else {
        console.log(this.FamilyDetailForm.value)
        this._apiService.addFamilyDetails(this.FamilyDetailForm.value)
          .subscribe({
            next: (result) => {
              alert("FamilyDetail Added Successfully")
              this._dialogRef.close(true)
              //this.toaster.success("Data Added Successfully")
  
            }
          })
      }
    }
    
  }

}

