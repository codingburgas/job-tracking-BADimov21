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

  createJobAd(jobAd: any) {
    return this.http.post(`${this.apiUrl}/JobAd/Add`, jobAd);
  }

  getJobAdById(id: number) {
    return this.http.get(`${this.apiUrl}/JobAd/GetById/${id}`);
  }

  updateJobAd(id: number, jobAd: any) {
    return this.http.put(`${this.apiUrl}/JobAd/Update/${id}`, jobAd);
  }

  deleteJobAd(adId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/JobAd/Delete/${adId}`);
  }
}