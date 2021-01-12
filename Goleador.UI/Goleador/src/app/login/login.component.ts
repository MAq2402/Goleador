import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { LoginCredentials } from '../shared/models/login-credentials.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.form = new FormGroup({
      password: new FormControl('', Validators.required),
      userName: new FormControl('', Validators.required)
    });

    if (this.authService.isLoggedIn()) {
      this.router.navigate(['']);
    }
  }

  submit() {
    const model: LoginCredentials = {
      password: this.form.controls.password.value,
      userName: this.form.controls.userName.value
    };

    this.authService.login(model).subscribe(() => {
      this.router.navigate(['']);
    });
  }
}
