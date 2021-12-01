import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { ManagerComponent } from './manager/manager.component';
import { UserComponent } from './user/user.component';
import {AuthGuard} from './shared/auth.guard'

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'',component:LoginComponent},
  {path: 'admin',component: AdminComponent,canActivate:[AuthGuard],data:{role:'1'}},
  {path: 'manager',component:ManagerComponent,canActivate:[AuthGuard],data:{role:'2'}},
  {path: 'user',component:UserComponent,canActivate:[AuthGuard],data:{role:'3'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
