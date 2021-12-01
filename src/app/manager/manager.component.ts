import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {

  loggedUserName:string;
  constructor(private authService:AuthService,private route:Router) { }

  ngOnInit(): void {
    this.loggedUserName=localStorage.getItem("username");
  }

  LogOut()
  {
   
    this.authService.LogOut();
    this.route.navigateByUrl("login");

  }
}
