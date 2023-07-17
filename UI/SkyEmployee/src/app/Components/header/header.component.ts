import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpAddEditComponent } from '../emp-add-edit/emp-add-edit.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent  implements OnInit{
  @Output() sideNavToggled= new EventEmitter<boolean>();
  menuStatus: boolean= false;

  constructor(){}
  ngOnInit(): void {
    
  }
  sideNavToggle(){
    this.menuStatus= !this.menuStatus;
    this.sideNavToggled.emit(this.menuStatus);
  }
}
