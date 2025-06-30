import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { JobAdsService } from '../../services/job-ads.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-job-ad',
  templateUrl: './edit-job-ad.component.html',
  imports: [CommonModule, FormsModule],
  standalone: true,
  styleUrls: ['./edit-job-ad.component.scss']
})
export class EditJobAdComponent implements OnInit {
  jobAdId!: number;
  jobAd: any = null;

  successMessage: string | null = null;
  errorMessage: string | null = null;
  isSaving = false;

  constructor(
    private route: ActivatedRoute,
    private jobAdsService: JobAdsService,
    private router: Router
  ) {}

  ngOnInit() {
    // Extract job ad ID from route parameters
    this.jobAdId = +this.route.snapshot.paramMap.get('id')!;
    this.loadJobAd();
  }

  // Load job ad data from the server
  loadJobAd() {
    this.jobAdsService.getJobAdById(this.jobAdId).subscribe({
      next: (data) => {
        this.jobAd = data;
        this.errorMessage = null;
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Обявата не беше намерена.';
        // Redirect back to list after 3 seconds
        setTimeout(() => this.router.navigate(['/job-ads']), 3000);
      }
    });
  }

  // Handle form submission for updating the job ad
  onSubmit() {
    if (!this.jobAd) return;

    this.isSaving = true;
    this.successMessage = null;
    this.errorMessage = null;

    this.jobAdsService.updateJobAd(this.jobAdId, this.jobAd).subscribe({
      next: () => {
        this.successMessage = 'Обявата беше редактирана успешно.';
        this.isSaving = false;

        // Navigate back to job ads list after 2 seconds
        setTimeout(() => this.router.navigate(['/job-ads']), 2000);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = 'Грешка при редакцията.';
        this.isSaving = false;
      }
    });
  }
}