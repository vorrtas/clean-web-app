import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private http: HttpClient) { }

  public token: string | null = null;

  public authorize(username: string, password: string) {
    this.http.post('http://localhost:5000/api/auth/login', { password: password, username: username })
      .subscribe({
        next: (val: any) => { this.token = val.token },
        error: (err: any) => { this.token = null }
      })
  }
}
