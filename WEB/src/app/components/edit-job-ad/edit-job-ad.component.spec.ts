import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditJobAdComponent } from './edit-job-ad.component';

describe('EditJobAdComponent', () => {
  let component: EditJobAdComponent;
  let fixture: ComponentFixture<EditJobAdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditJobAdComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditJobAdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
