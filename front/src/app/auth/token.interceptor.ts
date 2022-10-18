import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IdentityService } from "./identity.service";


@Injectable({ providedIn: 'root' })
export class TokenIterceptor implements HttpInterceptor {

  constructor(private identity: IdentityService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {


    if (this.identity.user !== null) {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json; charset=utf-8',
          'Accept': 'application/json',
          'Authorization': `Bearer ${this.identity.user!.token}`,
        },
      });
    }

    return next.handle(req);
  }
}
