import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class ValuesService {

  constructor(private http: HttpClient) { }

  public GetNumbers(): Observable<number[]> {
    return this.http.get<number[]>(environment.apiurl + '/values');
  }
}
