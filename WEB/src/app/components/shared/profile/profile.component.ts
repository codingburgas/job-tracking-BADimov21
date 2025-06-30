import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';

// ProfileComponent displays current user's information.
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  imports: [CommonModule],
  standalone: true,
})
export class ProfileComponent implements OnInit {
  user: any; // Holds the current user data

  constructor(private authService: AuthService) {}

  // On component init, retrieve user from the AuthService
  ngOnInit(): void {
    this.user = this.authService.getCurrentUser();
  }
}