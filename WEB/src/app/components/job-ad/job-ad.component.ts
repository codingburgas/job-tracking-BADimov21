import { Component, OnInit } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common';
import { JobAdsService } from '../../services/job-ads.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-job-ad',
  standalone: true,
  imports: [CommonModule, NgClass, FormsModule],
  templateUrl: './job-ad.component.html',
  styleUrls: ['./job-ad.component.scss']
})
export class JobAdComponent implements OnInit {
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

  constructor(private jobAdsService: JobAdsService) {}

  ngOnInit() {
    this.currentPage = 1;
    this.pageSize = 10;
    this.loadJobAds(this.currentPage);
  }

  applyFilters(): void {
    this.currentPage = 1;
    this.loadJobAds(this.currentPage);
  }

  loadJobAds(page: number) {
      console.log('Loading page:', page);

      if (page < 1) {
        console.warn('Page less than 1, ignoring');
        return;
      }
      if (this.totalPages > 0 && page > this.totalPages) {
        console.warn('Page exceeds totalPages, ignoring');
        return;
      }

      this.currentPage = page;

      this.jobAdsService.getJobAds(this.currentPage, this.pageSize, this.filters).subscribe(res => {
      console.log('API response:', res);
    
      this.jobAds = res.items;
      this.totalItems = res.totalCount;

      this.totalPages = Math.ceil(this.totalItems / this.pageSize);
      console.log('Total items:', this.totalItems, 'Total pages:', this.totalPages);

      this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
      console.log('Pages array:', this.pages);
    });
  }
  
  onPageClick(event: Event, page: number) {
    event.preventDefault();

    if (page < 1 || page > this.totalPages || page === this.currentPage) {
      return;
    }

    this.loadJobAds(page);
  }
}