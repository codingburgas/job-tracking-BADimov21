import { RouterModule, Routes } from '@angular/router';
import { JobAdComponent } from './components/job-ad/job-ad.component';
import { JobApplicationComponent } from './components/job-application/job-application.component';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';

export const routes: Routes = [
    { path: 'job-ads', component: JobAdComponent },
    { path: 'job-applications', component: JobApplicationComponent },
    { path: 'registration-form', component: RegistrationFormComponent},
    { path: 'login-form', component: LoginFormComponent }
];