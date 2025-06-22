import { Component } from '@angular/core';

import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup,  ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss'
})
export class LoginFormComponent {
  loginForm: FormGroup;
  showPassword = false;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: [''],
      password: [''],
    });
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  onLogin() {
    const { username, password } = this.loginForm.value;
    console.log('Login attempt:', username, password);
    // Add your login logic here
  }
}