import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-nav-bar',
  imports: [RouterLink, RouterModule, CommonModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
  standalone: true,
})
export class NavBarComponent {
  userRole: number | null = null;

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.userRole = this.authService.getUserRole();
  }

  onLogout() {
    this.authService.logout();
    this.router.navigate(['/login-form']);
  }
}
