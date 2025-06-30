import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    // Get the currently logged-in user
    const user = this.authService.getCurrentUser();

    // Allow access if user exists and role is admin (role === 1)
    if (user && user.role === 1) {
      return true;
    }

    // Otherwise, redirect to unauthorized page and deny access
    this.router.navigate(['/unauthorized']);
    return false;
  }
}