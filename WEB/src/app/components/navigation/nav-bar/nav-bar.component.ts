import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [RouterLink, RouterModule, CommonModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent {
  // Stores the current user's role (e.g., admin or regular user)
  userRole: number | null = null;

  constructor(
    public authService: AuthService, // Inject authentication service
    private router: Router           // Inject router for navigation
  ) {}

  // Runs on component initialization
  ngOnInit() {
    // Retrieve the user's role from the AuthService
    this.userRole = this.authService.getUserRole();
  }

  // Handles logout action
  onLogout() {
    this.authService.logout();         // Clear user session
    this.router.navigate(['/login-form']); // Redirect to login page
  }
}
