import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5230/api';

  constructor(private http: HttpClient) {}

  /**
   * Checks if there is a valid auth token in local storage.
   */
  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }

  /**
   * Clears user authentication data from local storage.
   */
  logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('user');
  }

  /**
   * Registers a new user by sending user data to the backend.
   * @param user - User data object
   * @returns Observable of the server response
   */
  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/User/Add`, user);
  }

  /**
   * Logs in a user by sending username and password to the backend.
   * On success, stores user data in local storage.
   * @param username 
   * @param password 
   * @returns Observable of user data
   */
  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/User/Login`, { username, password }).pipe(
      tap(user => {
        if (!user || !user.username) {
          throw new Error('Invalid login response');
        }
        localStorage.setItem('user', JSON.stringify(user));
      })
    );
  }

  /**
   * Retrieves the current logged-in user from local storage.
   * @returns User object or null if not found
   */
  getCurrentUser(): any {
    const userJson = localStorage.getItem('user');
    return userJson ? JSON.parse(userJson) : null;
  }

  /**
   * Returns the current user's ID.
   * @returns User ID string or null
   */
  getCurrentUserId(): string | null {
    const user = this.getCurrentUser();
    return user ? user.id : null;
  }

  /**
   * Returns the current user's role.
   * @returns Role number or null
   */
  getUserRole(): number | null {
    const user = this.getCurrentUser();
    return user ? user.role : null;
  }
}
