import { Routes } from '@angular/router';
import { Layout } from './layout/layout/layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { MyProjects } from './pages/myprojects/myprojects';
import { Login } from './pages/login/login';
import { authGuard } from './services/AuthGuard';
import { MyProfile } from './pages/myprofile/myprofile';

export const routes: Routes = [
    {
        path: '',
        component: Layout,
        canActivate: [authGuard],
        children: [
            {
                path: '',
                component: Dashboard
            },
            {
                path: 'my-projects',
                component: MyProjects
            },
            {
                path: 'my-profile',
                component: MyProfile
            }
        ]
    },
    {
        path: 'login',
        component: Login
    }
];
