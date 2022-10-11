import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IdentityService } from '../../services/identity.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private identity: IdentityService, private router: Router) { }

  username = new FormControl('');
  password = new FormControl('');

  Login() {
    this.identity.authorize(this.username.value ?? '', this.password.value ?? '');
  }

  Navigate() {
    this.router.navigateByUrl('values');
  }

  ngOnInit(): void {
  }

}
