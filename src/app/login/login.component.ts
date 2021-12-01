import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {Users} from'../shared/users';
import{AuthService} from '../shared/auth.service';
import{JwtResponse}from '../shared/jwt-response'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    loginForm!: FormGroup;
    
    isSubmitted = false;
    loginUser: Users = new Users;
    error = '';
  
    jwtResponse:any=new JwtResponse();
    constructor(private formbuilder: FormBuilder,
      private router: Router,public authService:AuthService
    ) { }
  
    ngOnInit(): void {
      this.loginForm = this.formbuilder.group(
        {
          UserName: ['', [Validators.required]],
          Password: ['', [Validators.required]],
        }
      );
    }
  
  
    //get form controls  details
  
    get formControls() {
      return this.loginForm.controls;
    }
  
  
    //login verify credentials
  
    LoginCredentials() {
  
      //console.log(this.loginForm.value);
      this.isSubmitted = true;
  
      // invalid
  
      if (this.loginForm.invalid)
        return;
  
  
  
      //valid
      if (this.loginForm.valid) {
  
        //calling method from Authservice 
        //calling token generation api
  
        this.authService.getTokenByPassword(this.loginForm.value).subscribe
        (data=>
          {
            console.log(data);
            this.jwtResponse=data;
            localStorage.setItem("token",data.token);// adding token to the local storage
            sessionStorage.setItem("token",data.token);//adding token to the session storage
            //check the role
            if(this.jwtResponse.RoleId===1)
                {
                  //logged as admin
                  console.log("Admin Module");
  
                  //adding details to localstorage and sessionstorage
                  localStorage.setItem("username",data.UserName);
                  sessionStorage.setItem("username",data.UserName);
                  localStorage.setItem("Access_Role",data.RoleId.toString());
  
                //based on role redirect out application
  
                  this.router.navigateByUrl("/admin");
  
                }
                
                  else if(this.jwtResponse.RoleId===2)
                  {
                  //logged as manager
                  console.log("HR Manager Module")
                  //adding details to localstorage and sessionstorage
                  localStorage.setItem("username",data.UserName);
                  sessionStorage.setItem("username",data.UserName);
                  localStorage.setItem("Access_Role",data.RoleId.toString());
                  //based on role redirect out application
                  this.router.navigateByUrl("/manager");
                }
               
                else if(this.jwtResponse.RoleId===3)
                {
                  //logged as customer
                  console.log("User Module");
                  //adding details to localstorage and sessionstorage
                  localStorage.setItem("username",data.UserName);
                  sessionStorage.setItem("username",data.UserName);
                  localStorage.setItem("Access_Role",data.RoleId.toString());
                  //based on role redirect out application
                  this.router.navigateByUrl("/user");
                }
                else{
  
                  this.error="Sorry .. invalid authorization"
                }
              },
              
          error=>
          {
            this.error="invalid"
          }
          )
      }
    }
   
  }
