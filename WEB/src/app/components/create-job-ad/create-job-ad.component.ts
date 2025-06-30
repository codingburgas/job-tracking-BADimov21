import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JobAdsService } from '../../services/job-ads.service';

@Component({
  selector: 'app-create-job-ad',
  imports: [CommonModule, FormsModule],
  templateUrl: './create-job-ad.component.html',
  styleUrls: ['./create-job-ad.component.scss'],
  standalone: true
})
export class CreateJobAdComponent {
  // Model for the job ad form, with default values
  jobAd = {
    title: '',
    companyName: '',
    description: '',
    publishedOn: new Date().toISOString().split('T')[0], // today's date in yyyy-MM-dd format
    isOpen: true,
  };

  alertMessage: string | null = null;  // Alert message text
  alertType: 'success' | 'danger' | null = null;  // Alert type for styling
  isSubmitting = false;  // Tracks if form submission is in progress

  constructor(private jobAdsService: JobAdsService, private router: Router) {}

  // Display alert message for 4 seconds
  showAlert(message: string, type: 'success' | 'danger') {
    this.alertMessage = message;
    this.alertType = type;
    setTimeout(() => {
      this.alertMessage = null;
      this.alertType = null;
    }, 4000);
  }

  // Handle form submission
  onSubmit() {
    if (this.isSubmitting) {
      return;  // Prevent duplicate submissions
    }
    
    this.isSubmitting = true;

    this.jobAdsService.createJobAd(this.jobAd).subscribe({
      next: () => {
        this.showAlert('Обявата беше успешно добавена.', 'success');
        setTimeout(() => {
          this.router.navigate(['/job-ads']);  // Redirect after success
        }, 1500);
      },
      error: (err) => {
        console.error(err);
        this.showAlert('Възникна грешка при добавянето на обявата.', 'danger');
        this.isSubmitting = false;
      },
      complete: () => {
        this.isSubmitting = false;
      }
    });
  }
}