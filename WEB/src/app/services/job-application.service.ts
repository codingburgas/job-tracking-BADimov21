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
}
