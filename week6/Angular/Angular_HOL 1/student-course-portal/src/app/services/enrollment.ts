import { Injectable } from '@angular/core';

export interface Course {
  id: number;
  name: string;
  code: string;
  credits: number;
  gradeStatus: 'passed' | 'failed' | 'pending';
}

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {
  private enrolledCourseIds: number[] = [];
  private cachedCourses: Course[] = [];

  setCourses(courses: Course[]) {
    this.cachedCourses = courses;
  }

  enroll(courseId: number): void {
    if (!this.isEnrolled(courseId)) {
      this.enrolledCourseIds.push(courseId);
    }
  }

  unenroll(courseId: number): void {
    this.enrolledCourseIds = this.enrolledCourseIds.filter(id => id !== courseId);
  }

  isEnrolled(courseId: number): boolean {
    return this.enrolledCourseIds.includes(courseId);
  }

  getEnrolledCourses(): Course[] {
    return this.cachedCourses.filter(c => this.enrolledCourseIds.includes(c.id));
  }
}