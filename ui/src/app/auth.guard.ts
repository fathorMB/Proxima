// src/app/auth.guard.ts
import { Injectable, inject } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  private router = inject(Router);

  canActivate(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      // You could add more validation logic here if needed.
      return true;
    }
    // Redirect to login if no valid token exists.
    this.router.navigate(['/login']);
    return false;
  }
}
