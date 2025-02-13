import { Routes } from '@angular/router';

export default [
    {
        path: '',
        loadComponent: () => import('./info.component').then(c => c.InfoComponent),
    }
] as Routes;