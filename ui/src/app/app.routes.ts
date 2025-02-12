import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    // Other routes (protected routes can be added here)
    { path: '', redirectTo: 'login', pathMatch: 'full' }
  ];
