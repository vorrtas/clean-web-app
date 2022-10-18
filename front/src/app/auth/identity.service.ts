import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../auth/User';

@Injectable({ providedIn: 'root' })
export class IdentityService {

  constructor(private http: HttpClient) { }

  public user: User | null = null;

  public login(username: string, password: string) {
    this.http.post(environment.apiurl + '/auth/login', { password: password, username: username })
      .subscribe({
        next: (val: any) => { this.user = val },
        error: (err: any) => { this.user = null }
      })
  }

  public logout() {
    this.user = null;
  }
}
