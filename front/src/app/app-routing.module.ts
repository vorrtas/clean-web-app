import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ValuesComponent } from './components/values/values.component';
import { TokenguardGuard } from './services/tokenguard.guard';

const routes: Routes = [
  { path: 'values', component: ValuesComponent, canActivate: [TokenguardGuard] },
  { path: '**', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
