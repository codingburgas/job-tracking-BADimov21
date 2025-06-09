import { Component } from '@angular/core';

@Component({
  selector: 'app-job-ad',
  imports: [],
  templateUrl: './job-ad.component.html',
  styleUrl: './job-ad.component.scss'
})
export class JobAdComponent {
  title: string = '';
  companyName: string = '';
  description: string = '';
  publishedOn: Date = new Date();
  isOpen: boolean = true;
}
