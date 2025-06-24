import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { jwtDecode } from 'jwt-decode';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }

  logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('user');
  }

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/User/Add`, user);
  }

  login(username: string, password: string) {
    return this.http.post<any>(`${this.apiUrl}/User/Login`, { username, password }).pipe(
      tap(user => {
        if (!user || !user.username) {
          throw new Error('Invalid login response');
        }

        localStorage.setItem('user', JSON.stringify(user));
      })
    );
  }

  getCurrentUser(): any {
    const userJson = localStorage.getItem('user');
    return userJson ? JSON.parse(userJson) : null;
  }

  getCurrentUserId(): string | null {
    const user = this.getCurrentUser();
    return user ? user.id : null;
  }

  getUserRole(): number | null {
    const user = this.getCurrentUser();
    return user ? user.role : null;
  }
}