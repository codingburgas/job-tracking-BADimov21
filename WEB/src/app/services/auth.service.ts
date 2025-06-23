import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }

  logout() {
    localStorage.removeItem('authToken');
  }

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/User/Add`, user);
  }

  login(username: string, password: string) {
    return this.http.post<{ token: string }>(`${this.apiUrl}/User/Login`, { username, password });
  }
}