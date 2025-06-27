import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login-form',
  imports: [RouterLink, ReactiveFormsModule, CommonModule],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
  standalone: true
})
export class LoginFormComponent {
  loginForm: FormGroup;
  showPassword = false;
  errorMessage: string | null = null;
  loginError = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  onLogin() {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;
      this.authService.login(username, password).subscribe({
        next: (response) => {
          console.log('Login success', response);
          this.loginError = false;
          localStorage.setItem('authToken', response.token);
          this.router.navigate(['/job-applications']);
        },
        error: (err) => {
          console.error('Login error', err);
          this.loginError = true;
        }
      });
    }
  }
}