import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobApplicationService } from '../../services/job-application.service';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-job-application',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './job-application.component.html',
  styleUrls: ['./job-application.component.scss']
})
export class JobApplicationComponent implements OnInit {
  totalItems = 0;
  pageSize = 10;
  currentPage = 1;
  totalPages = 1;
  pages: number[] = [];

  jobApplications: Array<{
    id: number;
    userId: number;
    jobAdId: number;
    status: number;
    user: {
      id: number;
      firstName: string | null;
      middleName: string | null;
      lastName: string | null;
      username: string;
      role: number;
    };
    jobAd: {
      id: number;
      title: string;
      companyName: string;
      description: string | null;
      publishedOn: string;
      isOpen: boolean;
    };
  }> = [];


  filters = {
    status: null as number | null,
    userId: null as number | null,
    jobAdId: null as number | null
  };

  constructor(private jobApplicationService: JobApplicationService, private authService: AuthService) {}

  ngOnInit() {
    this.currentPage = 1;
    this.pageSize = 10;
    this.loadJobApplications(this.currentPage);
  }

  applyFilters(): void {
    this.currentPage = 1;
    this.loadJobApplications(this.currentPage);
  }

  loadJobApplications(page: number) {
    const user = this.authService.getCurrentUser();
    const isAdmin = user.role === 1;

    const filters = {
      ...this.filters, 
      ...(isAdmin ? {} : { userId: user.id })
    };

    this.jobApplicationService
    .getJobApplications(this.currentPage, this.pageSize, filters)
    .subscribe(response => {
      this.jobApplications = response.items;
      this.totalItems = response.totalItems;
      this.totalPages = Math.ceil(this.totalItems / this.pageSize);
      this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
    });
  }


  onPageClick(event: Event, page: number): void {
    event.preventDefault();
    if (page >= 1 && page <= this.totalPages && page !== this.currentPage) {
      this.currentPage = page;
      this.loadJobApplications(page);
    }
  }
}