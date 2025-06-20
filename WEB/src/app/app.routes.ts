import { RouterModule, Routes } from '@angular/router';
import { JobAdComponent } from './components/job-ad/job-ad.component';
import { JobApplicationComponent } from './components/job-application/job-application.component';

export const routes: Routes = [
    { path: 'job-ads', component: JobAdComponent },
    { path: 'job-applications', component: JobApplicationComponent },
];