import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    // Check if the user is authenticated
    if (this.authService.isAuthenticated()) {
      return true; // Allow route activation
    }

    // If not authenticated, redirect to login page
    this.router.navigate(['/login-form']);
    return false; // Deny route activation
  }
}