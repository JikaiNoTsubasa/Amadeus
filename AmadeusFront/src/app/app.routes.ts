import { Routes } from '@angular/router';
import { Layout } from './layout/layout/layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { MyProjects } from './pages/myprojects/myprojects';

export const routes: Routes = [
    {
        path: '',
        component: Layout,
        children: [
            {
                path: '',
                component: Dashboard
            },
            {
                path: 'my-projects',
                component: MyProjects
            }
        ]
    }
];
