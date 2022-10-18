import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from 'src/app/auth/identity.service';

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
    this.identity.login(this.username.value ?? '', this.password.value ?? '');
  }

  Navigate() {
    this.router.navigateByUrl('values');
  }

  ngOnInit(): void {
  }

}
