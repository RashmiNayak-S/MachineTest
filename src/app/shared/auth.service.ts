import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Users } from './users';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,private router:Router) { }


  //function for getting user details by giving username and password
  getUserDetails(user:Users):Observable<any>{

  
   return this.httpClient.get(environment.apiUrl+"api/login/getuser/"+user.UserName+"/"+user.Password);

  }



  // function for geting token and userdetails by passing username and password
  getTokenByPassword(user:Users):Observable<any>{

    console.log("Token generation")
    
   return this.httpClient.get(environment.apiUrl+"api/login/"+user.UserName+"/"+user.Password);

  }


  // clearing all localstorage and session storage data while logout
  public LogOut()
  {
    
    localStorage.clear();
    sessionStorage.clear()
  }


}

