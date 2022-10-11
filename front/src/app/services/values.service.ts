import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IdentityService } from './identity.service';

@Injectable({
  providedIn: 'root'
})
export class ValuesService {

  constructor(private identity: IdentityService, private http: HttpClient) { }

  public GetNumbers() {
    return this.http.get('http://localhost:5000/api/values', { headers: { 'Authorization': `Bearer ${this.identity.token}` } });
  }
}
