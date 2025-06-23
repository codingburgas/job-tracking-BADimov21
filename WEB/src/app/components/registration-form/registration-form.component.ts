import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-registration-form',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './registration-form.component.html',
  styleUrl: './registration-form.component.scss',
})
export class RegistrationFormComponent {
  registerForm: FormGroup;
  showPassword = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      firstName: [''],
      middleName: [''],
      lastName: [''],
      username: [''],
      password: [''],
      confirmPassword: [''],
      role: [0],
    });
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  onSubmit() {
    if (this.registerForm.valid) {
      const formValue = this.registerForm.value;

      if (formValue.password !== formValue.confirmPassword) {
        alert('Паролите не съвпадат!');
        return;
      }

      this.authService.register(formValue).subscribe({
        next: () => {
          alert('Успешна регистрация!');
          this.router.navigate(['/login-form']);
        },
        error: (err) => {
          console.error('Registration error:', err);
          alert('Възникна грешка при регистрацията. Виж конзолата за подробности.');
        }
      });
    }
  }
}