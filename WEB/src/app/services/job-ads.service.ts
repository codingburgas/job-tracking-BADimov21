// job-ads.service.ts or job.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class JobAdsService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  getJobAds(page: number, pageSize: number, filters: any): Observable<any> {
    return this.http.post<any>('http://localhost:5230/api/JobAd/GetFiltered', {
      page,
      pageSize,
      filters
    });
  }
}