import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/Services/api.service';

@Component({
  selector: 'app-emp-add-edit',
  templateUrl: './emp-add-edit.component.html',
  styleUrls: ['./emp-add-edit.component.scss']
})
export class EmpAddEditComponent implements OnInit {
  step:any =1;
  displayMsg: string ='';
  isEmployeeCreated:boolean=false;
  employees: any[] = [];
  addressTypes: any[]=[];
  relations: any[]=[];
  


  submitted:any =false;
  multistep = new FormGroup({
    empDetails: new FormGroup({
      EmpCode: new FormControl('',Validators.required),
      FirstName: new FormControl('',Validators.required),
      MiddleName:new FormControl(''),
      LastName:new FormControl('',Validators.required),
      Email:new FormControl('',[Validators.required,Validators.email]),
      DOJ:new FormControl('',Validators.required),
      DOB:new FormControl('',Validators.required),
      Phone:new FormControl('',Validators.required),
      Mobile:new FormControl('',Validators.required),
      Gender:new FormControl('',Validators.required),
      Designation:new FormControl('',Validators.required),
      EmergencyContactNo:new FormControl('',Validators.required),
      EmergencyContactName:new FormControl('',Validators.required)
      
    }),
    AddressDetails: new FormGroup({
      Address: new FormControl('',Validators.required),
      AddressTypeId: new FormControl('',Validators.required),
      EmployeeId:new FormControl('',Validators.required),
      City:new FormControl('',Validators.required),
      State:new FormControl('',Validators.required),
      Country:new FormControl('',Validators.required),
      PinCode:new FormControl('',Validators.required)
     
    }),
    FamilyDetails: new FormGroup({
      EmployeeId: new FormControl('',Validators.required),
      FirstName: new FormControl('',Validators.required),
      MiddleName:new FormControl(''),
      LastName:new FormControl('',Validators.required),
      DOB:new FormControl('',Validators.required),
      Gender:new FormControl('',Validators.required),
      RelationId:new FormControl('',Validators.required)

    })

  })
  AddressDetailsFormGroup: any;
 

  constructor(private route:Router,private _apiService:ApiService) { 
  
  }

  ngOnInit() {
    this._apiService.getAllEmployee().subscribe({
      next:(res)=>{
        this.employees = res;
      }
    }),
   
    this._apiService.GetAllAddressType().subscribe({
      next:(res)=>{
       this.addressTypes=res;
      }
    }),
    this._apiService.GetAllRelation().subscribe({
      next:(res)=>{
        this.relations=res;
      }
    })

    


  }
  
  // get empDetails(){
    
  //  // console.log(this.multistep.controls['empDetails']['controls'])
  //    return this.multistep.controls['empDetails']['controls'];

  // }
  // get AddressDetails(){
  //   return this.multistep.controls['AddressDetails']['controls'];
  // }
  
  submit(){
    this.submitted= true;
    if(this.step == 1){
      this._apiService
      .addEmployee(this.multistep.value.empDetails)
      .subscribe((result: any)=>{
          console.log(result);
        }
      )
    }
    
    if(this.step == 2){
      this._apiService
      .addAddress(this.multistep.value.AddressDetails)
      .subscribe((result:any)=>{
        console.log(result);
        const empDetailsFormGroup = this.multistep.get('empDetails') as FormGroup;
        const addressDetailsFormGroup =this.multistep.get('AddressDetails') as FormGroup;
        const employeeIdFormControl = this.AddressDetailsFormGroup.get('EmployeeId') as FormControl;
        const empCodeFormControl = empDetailsFormGroup.get('FistName') as FormControl;
        if (empDetailsFormGroup && addressDetailsFormGroup && employeeIdFormControl && empCodeFormControl) {
          employeeIdFormControl.setValue(empCodeFormControl.value);
        }
      
        console.log(this.multistep);

      })
    }
    if(this.step == 3){
      this._apiService
      .addFamilyDetails(this.multistep.value.FamilyDetails)
      .subscribe((result:any)=>{
        console.log(result);
      })
    }
    this.step = this.step + 1;
    if(this.step == 4){
      this.route.navigate(['/EmployeeList'])
    }
    
  }
  Previous(){
    this.step= this.step - 1;
  }
}


