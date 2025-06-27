import { Component, OnInit } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common';
import { Router } from '@angular/router';
import { JobAdsService } from '../../services/job-ads.service';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { JobApplicationService } from '../../services/job-application.service';

@Component({
  selector: 'app-job-ad',
  standalone: true,
  imports: [CommonModule, NgClass, FormsModule],
  templateUrl: './job-ad.component.html',
  styleUrls: ['./job-ad.component.scss']
})
export class JobAdComponent implements OnInit {
  userRole: number | null = null;

  totalItems = 0;
  pageSize = 10;
  currentPage = 1;
  totalPages = 1;
  pages: number[] = [];
  jobAds: any[] = [];

  filters = {
    isOpen: null,
    title: '',
    companyName: '',
    publishedOn: null as string | null
  };

  appliedJobAdIds: number[] = [];
  applyingJobId: number | null = null;

  alertMessage: string | null = null;
  alertType: 'success' | 'danger' | 'warning' | null = null;

  isDeleting: boolean = false;
  deletingJobAdId: number | null = null;
  showDeleteModal: boolean = false;

  constructor(
    private jobAdsService: JobAdsService,
    private jobApplicationService: JobApplicationService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.currentPage = 1;
    this.pageSize = 10;
    this.userRole = this.authService.getUserRole();
    this.loadJobAds(this.currentPage);
  }

  showAlert(message: string, type: 'success' | 'danger' | 'warning' = 'success') {
    this.alertMessage = message;
    this.alertType = type;

    setTimeout(() => {
      this.alertMessage = null;
      this.alertType = null;
    }, 4000);
  }

  isApplied(jobAdId: number): boolean {
    return this.appliedJobAdIds.includes(jobAdId);
  }

  onApply(job: any) {
    const currentUser = this.authService.getCurrentUser();

    if (!currentUser || !currentUser.id) {
      this.showAlert('Потребителят не е влязъл в системата.', 'danger');
      return;
    }

    this.applyingJobId = job.id;

    this.jobApplicationService.applyToJob(job.id, currentUser.id).subscribe({
      next: () => {
        this.showAlert('Успешно кандидатстване!', 'success');
        this.appliedJobAdIds.push(job.id);
        this.applyingJobId = null;
      },
      error: (err) => {
        this.applyingJobId = null;

        if (
          err.status === 400 &&
          err.error?.message?.includes('already applied')
        ) {
          this.showAlert('Вече сте кандидатствали за тази позиция.', 'warning');
        } else if (
          err.status === 200 || 
          (err.status === 0 && this.isApplied(job.id))
        ) {
          this.showAlert('Успешно кандидатстване!', 'success');
        } else {
          this.showAlert('Грешка при кандидатстване.', 'danger');
          console.error('Unexpected apply error:', err);
        }
      }
    });
  }

  onAddJobAd() {
    this.router.navigate(['/create-job-ad']);
  }

  onEditJobAd(ad: any): void {
    this.router.navigate(['/edit-job-ad', ad.id]);
  }

  onDeleteJobAd(adId: number): void {
    const confirmed = confirm('Сигурни ли сте, че искате да изтриете тази обява?');
    if (confirmed) {
      this.jobAdsService.deleteJobAd(adId).subscribe({
        next: () => {
          this.showAlert('Обявата беше изтрита успешно.', 'success');
          this.loadJobAds(this.currentPage);
        },
        error: (err) => {
          console.error('Грешка при изтриването:', err);
          this.showAlert('Грешка при изтриването на обявата.', 'danger');
        }
      });
    }
  }

  applyFilters(): void {
    this.userRole = this.authService.getUserRole();
    this.currentPage = 1;
    this.loadJobAds(this.currentPage);
  }

  loadJobAds(page: number) {
    if (page < 1 || (this.totalPages > 0 && page > this.totalPages)) {
      return;
    }

    this.currentPage = page;

    this.jobAdsService.getJobAds(this.currentPage, this.pageSize, this.filters).subscribe({
      next: (res) => {
        this.jobAds = res.items;
        this.totalItems = res.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
        this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
      },
      error: (err) => {
        this.showAlert('Грешка при зареждането на обявите.', 'danger');
        console.error(err);
      }
    });
  }

  onPageClick(event: Event, page: number) {
    event.preventDefault();
    if (page < 1 || page > this.totalPages || page === this.currentPage) {
      return;
    }
    
    this.loadJobAds(page);
  }

  openDeleteModal(adId: number) {
    this.deletingJobAdId = adId;
    this.showDeleteModal = true;
  }

  closeDeleteModal() {
    this.deletingJobAdId = null;
    this.showDeleteModal = false;
  }

  confirmDelete() {
    if (this.deletingJobAdId === null) {
      return;
    }

    this.isDeleting = true;
    this.jobAdsService.deleteJobAd(this.deletingJobAdId).subscribe({
      next: () => {
        this.showAlert('Обявата беше изтрита успешно.', 'success');
        this.loadJobAds(this.currentPage);
        this.closeDeleteModal();
        this.isDeleting = false;
      },
      error: (err) => {
        console.error('Грешка при изтриването:', err);
        this.showAlert('Грешка при изтриването на обявата.', 'danger');
        this.isDeleting = false;
      }
    });
  }
}
