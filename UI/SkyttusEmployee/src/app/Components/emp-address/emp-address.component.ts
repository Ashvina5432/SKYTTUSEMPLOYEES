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
  selector: 'app-emp-address',
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
  templateUrl: './emp-address.component.html',
  styleUrls: ['./emp-address.component.scss']
})
export class EmpAddressComponent implements OnInit {
  employees: any[] = [];
  addressTypes: any[]=[];
  addressForm:FormGroup;
  address: string[ ]=[
    'address',
    'addressTypeId',
    'employeeId',
    'city',
    'state',
    'country',
    'pinCode',
    
    
  ];
  constructor(private fb: FormBuilder,private _apiService: ApiService,private _dialogRef:MatDialogRef<EmpAddressComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any ) {
    this.addressForm = this.fb.group({
      address: ['', Validators.required],
      addressTypeId: ['', Validators.required],
      employeeId: ['',Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      country: ['', Validators.required],
      pinCode:['',Validators.required],

    });
  }ngOnInit(): void {
    this.addressForm.patchValue(this.data);
    this._apiService.getAllEmployee().subscribe({
      next:(res)=>{
        this.employees = res;
      }
    }),
   
    this._apiService.GetAllAddressType().subscribe({
      next:(res)=>{
       this.addressTypes=res;
      }
    })
  }
  // onFormSubmit(){
  //   if(this.addressForm.valid){
  //     if(this.data)if(this.data){
  //       this._apiService.updateAddress(this.data.id,this.addressForm.value)
  //       .subscribe({
  //           next:(val:any)=>{
  //         alert('Address Updated successfully')
  //         this._dialogRef.close(true);
              
  //           },
  //           error:(err)=>{
  //             console.error(err)
  //           }
  //         })
  //     }else{
  //       this._apiService.addEmployee(this.addressForm.value)
  //       .subscribe({
  //           next:(val:any)=>{
  //         alert('Address added successfully')
  //         this._dialogRef.close(true);
              
  //           },
  //           error:(err)=>{
  //             console.error(err)
  //           }
  //         })
  //     }
  //   }
    
  // }
  onFormSubmit(){
    if(this. addressForm.valid){
      if (this.data) {
        console.log(this.addressForm.value)
        this._apiService.updateAddress(this.data.id, this.addressForm.value)
          .subscribe({
            next: (val:any) => {
               alert("Address Updated")
              this._dialogRef.close(true)
              //this.toaster.success("Data Updated Successfully")
  
            }
          })
      }
      else {
        console.log(this.addressForm.value)
        this._apiService.addAddress(this.addressForm.value)
          .subscribe({
            next: (val:any) => {
              alert("Address Added Successfully")
              this._dialogRef.close(true)
              //this.toaster.success("Data Added Successfully")
  
            }
          })
      }
    }
    
  }
}
