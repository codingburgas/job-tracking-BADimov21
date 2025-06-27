import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobApplicationReviewComponent } from './job-application-review.component';

describe('JobApplicationReviewComponent', () => {
  let component: JobApplicationReviewComponent;
  let fixture: ComponentFixture<JobApplicationReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JobApplicationReviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobApplicationReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
