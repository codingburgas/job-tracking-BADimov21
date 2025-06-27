import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class JobApplicationService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  getJobApplications(page: number, pageSize: number, filters: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/JobApplication/GetFiltered`, {
      page,
      pageSize,
      filters
    });
  }

  getJobApplicationById(id: number) {
    return this.http.get(`${this.apiUrl}/JobApplication/GetById/${id}`);
  }

  updateJobApplication(dto: { id: number; status?: number }) {
    return this.http.put(`${this.apiUrl}/JobApplication/Update/${dto.id}`, dto);
  }

  applyToJob(jobAdId: number, userId: number): Observable<any> {
    const payload = {
      jobAdId: jobAdId,
      userId: userId,
      status: 0
    };

    return this.http.post(`${this.apiUrl}/JobApplication/Add`, payload);
  }
}