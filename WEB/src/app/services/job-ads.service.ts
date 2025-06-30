import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class JobAdsService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  /**
   * Retrieves paginated and filtered job ads from the backend.
   * @param page - current page number
   * @param pageSize - number of items per page
   * @param filters - filtering criteria object
   * @returns Observable with job ads data
   */
  getJobAds(page: number, pageSize: number, filters: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/JobAd/GetFiltered`, {
      page,
      pageSize,
      filters
    });
  }

  /**
   * Creates a new job advertisement.
   * @param jobAd - job ad data object
   * @returns Observable of creation result
   */
  createJobAd(jobAd: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/JobAd/Add`, jobAd);
  }

  /**
   * Fetches a single job advertisement by ID.
   * @param id - job ad ID
   * @returns Observable with job ad details
   */
  getJobAdById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/JobAd/GetById/${id}`);
  }

  /**
   * Updates an existing job ad by ID.
   * @param id - job ad ID
   * @param jobAd - updated job ad data
   * @returns Observable of update result
   */
  updateJobAd(id: number, jobAd: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/JobAd/Update/${id}`, jobAd);
  }

  /**
   * Deletes a job ad by ID.
   * @param adId - job ad ID
   * @returns Observable of deletion result (void)
   */
  deleteJobAd(adId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/JobAd/Delete/${adId}`);
  }
}