import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../enviroment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseApiUrl: string = environment.baseApiUrl;
  

  constructor(private http: HttpClient) { }
// Employee
  getAllEmployee():Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'Employee/GetAllEmployee');
  }
  addEmployee(addEmployeeRequest:any):Observable<any>{
    addEmployeeRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<any>(this.baseApiUrl + 'Employee/AddEmployee', addEmployeeRequest);
  }
  
  GetEmployee(empcode :string):Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'Employee/Get?empcode='+empcode);
  }
  updateEmployee(id:string,employee:any):Observable<any>{
    return this.http.put<any>(this.baseApiUrl + 'Employee/Update?id='+id,employee);
  }
  
  delateEmployee(id:string):Observable<any>{
    return this.http.delete<any>(this.baseApiUrl + 'Employee/Delete?id='+id);
  }
  

  //Address
  getAllAddress():Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'EmployeeAddress/GetAllAddress');
  }
  addAddress(addEmpaddress:any):Observable<any>{
    addEmpaddress.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<any>(this.baseApiUrl + 'EmployeeAddress/AddAddress', addEmpaddress);
  }
  
  GetAddress(id :string):Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'EmployeeAddress/GetAddress?id='+id);
  }
  updateAddress(id:string,address:any):Observable<any>{
    return this.http.put<any>(this.baseApiUrl + 'EmployeeAddress/UpdateAddress?id='+id,address);
  }
  
  delateAddress(id:string):Observable<any>{
    return this.http.delete<any>(this.baseApiUrl + 'EmployeeAddress/DeleteAddress?id='+id);
  }
  //FamilyDetail

  getAllFamilyDetails():Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'FamilyDetails/GetFamilyDetails');
  }
  addFamilyDetails(addfamilyDetails:any):Observable<any>{
    addfamilyDetails.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<any>(this.baseApiUrl + 'FamilyDetails/AddFmilyDetails', addfamilyDetails);
  }
  
  GetFamilyDetails(id :string):Observable<any>{
    return this.http.get<any>(this.baseApiUrl + 'FamilyDetails/Search?id='+id);
  }
  updateFamilyDetails(id:string,familyDetails:any):Observable<any>{
    return this.http.put<any>(this.baseApiUrl + 'FamilyDetails/UpdateFmilyDetail?id='+id,familyDetails);
  }
  
  delateFamilyDetails(id:string):Observable<any>{
    return this.http.delete<any>(this.baseApiUrl + 'FamilyDetails/Delete?id='+id);
  }
 //AddrressType
 GetAllAddressType():Observable<any>{
  return this.http.get<any>(this.baseApiUrl + 'AddressType/GetAllAddressType');
}
//RelationType
GetAllRelation():Observable<any>{
  return this.http.get<any>(this.baseApiUrl + 'EmployeeRelation/GetAllRelation');
}
}

