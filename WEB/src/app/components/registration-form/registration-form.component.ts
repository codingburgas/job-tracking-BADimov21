import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  ValidationErrors,
  ValidatorFn,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-registration-form',
  imports: [RouterLink, ReactiveFormsModule, CommonModule],
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss'],
})
export class RegistrationFormComponent {
  registerForm: FormGroup;
  showPassword = false;
  registrationError: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.registerForm = this.fb.group(
      {
        firstName: ['', [Validators.required, this.nameValidator()]],
        middleName: ['', [Validators.required, this.nameValidator()]],
        lastName: ['', [Validators.required, this.nameValidator()]],
        username: ['', [Validators.required, this.usernameValidator()]],
        password: ['', [Validators.required, this.passwordComplexityValidator()]],
        confirmPassword: ['', Validators.required],
        role: [0],
      },
      { validators: this.passwordsMatch }
    );
  }

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  // Name validator: at least 2 letters, only letters, at least one capital
  nameValidator(): ValidatorFn {
    const lettersOnly = /^[A-Za-z]+$/;
    return (control: AbstractControl): ValidationErrors | null => {
      const val = control.value;
      if (!val) return null;
      if (!lettersOnly.test(val)) return { pattern: true };
      if (val.length < 2) return { minlength: { requiredLength: 2, actualLength: val.length } };
      if (!/[A-Z]/.test(val)) return { capitalLetter: true };
      return null;
    };
  }

  // Middle name is optional but if present, must be valid
  optionalNameValidator(): ValidatorFn {
    const lettersOnly = /^[A-Za-z]*$/; // allow empty string
    return (control: AbstractControl): ValidationErrors | null => {
      const val = control.value;
      if (!val) return null; // empty is allowed
      if (!lettersOnly.test(val)) return { pattern: true };
      if (val.length > 0 && val.length < 2) return { minlength: { requiredLength: 2, actualLength: val.length } };
      if (val.length > 0 && !/[A-Z]/.test(val)) return { capitalLetter: true };
      return null;
    };
  }

  // Username: at least 3 characters
  usernameValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const val = control.value;
      if (!val) return null;
      return val.length >= 3 ? null : { minlength: { requiredLength: 3, actualLength: val.length } };
    };
  }

  // Password complexity: min 8 chars, upper, lower, number, special
  passwordComplexityValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const val: string = control.value || '';
      if (!val) return null;

      const errors: ValidationErrors = {};
      if (val.length < 8) errors['minlength'] = { requiredLength: 8, actualLength: val.length };
      if (!/[A-Z]/.test(val)) errors['uppercase'] = true;
      if (!/[a-z]/.test(val)) errors['lowercase'] = true;
      if (!/\d/.test(val)) errors['number'] = true;
      if (!/[!@#$%^&*\~\?]/.test(val)) errors['specialChar'] = true;

      return Object.keys(errors).length > 0 ? errors : null;
    };
  }

  // Passwords match validator for the whole form group
  passwordsMatch(group: AbstractControl): ValidationErrors | null {
    const pass = group.get('password')?.value;
    const confirm = group.get('confirmPassword')?.value;
    return pass === confirm ? null : { passwordMismatch: true };
  }

  onSubmit() {
    this.registrationError = null;

    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    this.authService.register(this.registerForm.value).subscribe({
      next: () => {
        this.router.navigate(['/login-form']);
      },
      error: (err) => {
        console.error('Registration error:', err);
        if (err.status === 409 || err.error?.message?.includes('already exists') || err.error?.message?.toLowerCase().includes('вече съществува')) {
          this.registrationError = 'Потребителското име вече съществува.';
        } else if (err.status === 500) {
          this.registrationError = 'Сървърна грешка. Моля, опитайте отново по-късно.';
        } else {
          this.registrationError = 'Възникна грешка при регистрацията.';
        }
      },
    });
  }
}
