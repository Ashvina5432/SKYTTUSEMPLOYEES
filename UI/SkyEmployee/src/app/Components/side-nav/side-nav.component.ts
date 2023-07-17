import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit{
 @Input() sideNavStatus: boolean=false; 
list=[
  {
    number:'1',
    name:'EmployeeList',
    icon:'fa-solid fa-user '
  },
  
]

  constructor(){}
  ngOnInit(): void {
    
  }
}
