import { Component } from '@angular/core';
import { ApplicationStatusEnum } from '../../models/enums/application-status.enum';

@Component({
  selector: 'app-job-application',
  templateUrl: './job-application.component.html',
  styleUrl: './job-application.component.scss'
})
export class JobApplicationComponent {
  userId: number = 0;
  jobAdId: number = 0;
  status: ApplicationStatusEnum = ApplicationStatusEnum.SUBMITTED;
}