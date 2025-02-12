// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './auth.guard';

// Optionally, you can create additional dashboard child components (like DashboardHomeComponent)
// and add them as children to the dashboard route.
export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
    children: [
      // For example, a default home view for the dashboard.
      // { path: '', component: DashboardHomeComponent },
    ]
  },
  // Redirect the empty path to the dashboard (this will trigger the AuthGuard)
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  // Wildcard route for any unknown paths.
  { path: '**', redirectTo: '/dashboard' }
];
