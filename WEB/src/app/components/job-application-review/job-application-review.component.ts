import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobApplicationService } from '../../services/job-application.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-job-application-review',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './job-application-review.component.html',
  styleUrls: ['./job-application-review.component.scss']
})
export class JobApplicationReviewComponent implements OnInit {
  applicationId!: number;
  selectedStatus: number | null = null;

  successMessage: string | null = null;
  errorMessage: string | null = null;

  // Holds the loaded job application data
  application: {
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
  } | null = null;

  constructor(
    private route: ActivatedRoute,
    private jobApplicationService: JobApplicationService
  ) {}

  ngOnInit(): void {
    // Subscribe to route params and load the application by ID
    this.route.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      if (!id) {
        return; // Exit if ID is invalid
      }
      
      this.applicationId = id;

      // Fetch application data from service
      this.jobApplicationService.getJobApplicationById(id).subscribe({
        next: (data: any) => {
          this.application = data;
          this.selectedStatus = data.status; // Initialize selected status
        },
        error: (err: any) => {
          console.error('Error loading job application', err);
          this.errorMessage = 'Грешка при зареждане на кандидатурата.';
        }
      });
    });
  }

  // Handler for status change form submission
  onStatusChange(status: number | null): void {
    this.successMessage = null;
    this.errorMessage = null;

    if (status === null) {
      this.errorMessage = 'Моля, изберете статус.';
      return;
    }

    const updateDto = {
      id: this.applicationId,
      status: status
    };

    // Send updated status to backend
    this.jobApplicationService.updateJobApplication(updateDto).subscribe({
      next: () => {
        this.successMessage = 'Статусът беше успешно обновен.';
        if (this.application) {
          this.application.status = status; // Update local data
        }
      },
      error: (err: any) => {
        console.error('Error updating job application', err);
        this.errorMessage = 'Възникна грешка при обновяване на статуса.';
      }
    });
  }
}
