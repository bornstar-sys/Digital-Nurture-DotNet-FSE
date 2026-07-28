import { TestBed } from '@angular/core/testing';
import { EnrollmentService } from './enrollment';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EnrollmentService', () => {
  let service: EnrollmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(EnrollmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should enroll a course', () => {
    service.enroll(1);
    expect(service.isEnrolled(1)).toBe(true);
  });

  it('should unenroll a course', () => {
    service.enroll(1);
    service.unenroll(1);
    expect(service.isEnrolled(1)).toBe(false);
  });
});