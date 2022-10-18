import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { IdentityService } from "./identity.service";


@Injectable({
  providedIn: 'root'
})
export class TokenGuard implements CanActivate {

  constructor(private identity: IdentityService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return !(this.identity.user === null);
  }
}
