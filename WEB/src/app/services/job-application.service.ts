import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class JobApplicationService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  /**
   * Retrieves paginated and filtered job applications.
   * @param page - current page number
   * @param pageSize - number of items per page
   * @param filters - filtering criteria object
   * @returns Observable with job applications data
   */
  getJobApplications(page: number, pageSize: number, filters: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/JobApplication/GetFiltered`, {
      page,
      pageSize,
      filters
    });
  }

  /**
   * Gets a single job application by ID.
   * @param id - application ID
   * @returns Observable with job application details
   */
  getJobApplicationById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/JobApplication/GetById/${id}`);
  }

  /**
   * Updates job application status or other fields.
   * @param dto - object containing application ID and optional status
   * @returns Observable of update result
   */
  updateJobApplication(dto: { id: number; status?: number }): Observable<any> {
    return this.http.put(`${this.apiUrl}/JobApplication/Update/${dto.id}`, dto);
  }

  /**
   * Submits a new job application.
   * @param jobAdId - ID of the job ad to apply to
   * @param userId - ID of the user applying
   * @returns Observable of creation result
   */
  applyToJob(jobAdId: number, userId: number): Observable<any> {
    const payload = {
      jobAdId,
      userId,
      status: 0 // default initial status
    };

    return this.http.post(`${this.apiUrl}/JobApplication/Add`, payload);
  }
}
