import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from './identity.service';

@Injectable({
  providedIn: 'root'
})
export class TokenguardGuard implements CanActivate {

  constructor(private identity: IdentityService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    console.log(this.identity.token)
    return !(this.identity.token === null);
  }

}
