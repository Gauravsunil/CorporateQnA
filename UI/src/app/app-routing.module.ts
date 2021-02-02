import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    redirectTo:'user',
    pathMatch:'full'
  },
  {
    path:'authentication',
    loadChildren:()=>import('../app/authentication/authentication.module').then((m)=>m.AuthenticationModule)
  },
  {
    path:'user',
    loadChildren:()=>import('../app/user/user.module').then((m)=>m.UserModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
