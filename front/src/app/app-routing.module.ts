import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TokenGuard } from './auth/token.guard';
import { LoginComponent } from './components/login/login.component';
import { ValuesComponent } from './components/values/values.component';

const routes: Routes = [
  { path: 'values', component: ValuesComponent, canActivate: [TokenGuard] },
  { path: '**', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
