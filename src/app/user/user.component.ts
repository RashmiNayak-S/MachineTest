import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

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
