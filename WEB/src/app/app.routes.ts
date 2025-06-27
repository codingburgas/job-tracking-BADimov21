import { RouterModule, Routes } from '@angular/router';
import { JobAdComponent } from './components/job-ad/job-ad.component';
import { JobApplicationComponent } from './components/job-application/job-application.component';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './guards/auth.guard';
import { ProfileComponent } from './components/profile/profile.component';
import { CreateJobAdComponent } from './components/create-job-ad/create-job-ad.component';
import { EditJobAdComponent } from './components/edit-job-ad/edit-job-ad.component';
import { JobApplicationReviewComponent } from './components/job-application-review/job-application-review.component';
import { AdminGuard } from './guards/admin.guard';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';

export const routes: Routes = [
  { path: '', redirectTo: '/job-ads', pathMatch: 'full' },
  { path: 'login-form', component: LoginFormComponent },
  { path: 'registration-form', component: RegistrationFormComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },

  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'job-ads', component: JobAdComponent, canActivate: [AuthGuard] },
  { path: 'job-applications', component: JobApplicationComponent, canActivate: [AuthGuard] },
  { path: 'create-job-ad', component: CreateJobAdComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'edit-job-ad/:id', component: EditJobAdComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'job-application-review/:id', component: JobApplicationReviewComponent, canActivate: [AuthGuard, AdminGuard] },

  { path: '**', redirectTo: 'login-form' }
];