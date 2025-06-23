import { RouterModule, Routes } from '@angular/router';
import { JobAdComponent } from './components/job-ad/job-ad.component';
import { JobApplicationComponent } from './components/job-application/job-application.component';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: '/job-ads', pathMatch: 'full' },
  { path: 'login-form', component: LoginFormComponent },
  { path: 'registration-form', component: RegistrationFormComponent },
  { path: 'job-ads', component: JobAdComponent, canActivate: [AuthGuard] },
  { path: 'job-applications', component: JobApplicationComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'login-form' }
];