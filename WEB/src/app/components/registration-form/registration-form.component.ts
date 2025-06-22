import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup,  ReactiveFormsModule } from '@angular/forms';
import { ParseSourceFile } from '@angular/compiler';

@Component({
  selector: 'app-registration-form',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './registration-form.component.html',
  styleUrl: './registration-form.component.scss'
})
export class RegistrationFormComponent {
  registerForm: FormGroup;
  showPassword = false;

  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      firstName: [''],
      middleName: [''],
      lastName: [''],
      username: [''],
      password: [''],
      confirmPassword: [''],
      role: [0],  // Always 0, hidden from form
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
      console.log('Регистрация:', formValue);
      // Your registration logic here
    }
  }
}