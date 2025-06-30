import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.scss']
})
export class UnauthorizedComponent {
  constructor(private router: Router) {}

  // Navigate user back to the home page
  goBack() {
    this.router.navigate(['home']);
  }
}