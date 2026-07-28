import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CourseCard } from '../../components/course-card/course-card';
import { Course } from '../../services/course';
import { EnrollmentService } from '../../services/enrollment';
import { loadCourses } from '../../store/course/course.actions';
import { selectAllCourses, selectCoursesLoading, selectCoursesError } from '../../store/course/course.selectors';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, CommonModule, CourseCard],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit, OnDestroy {
  portalName = 'Student Course Portal';
  isPortalActive = true;
  message = '';
  searchTerm = '';
  selectedCourseId: number | null = null;
  courses$!: Observable<Course[]>;
  loading$!: Observable<boolean>;
  error$!: Observable<string | null>;

  constructor(
    private store: Store,
    private enrollmentService: EnrollmentService
  ) {}

  onEnrollClick() {
    this.message = 'Enrollment opened!';
  }

  onCourseEnroll(courseId: number) {
    if (this.enrollmentService.isEnrolled(courseId)) {
      this.enrollmentService.unenroll(courseId);
    } else {
      this.enrollmentService.enroll(courseId);
    }
    this.selectedCourseId = courseId;
  }

  isEnrolled(courseId: number): boolean {
    return this.enrollmentService.isEnrolled(courseId);
  }

  ngOnInit() {
    this.courses$ = this.store.select(selectAllCourses);
    this.loading$ = this.store.select(selectCoursesLoading);
    this.error$ = this.store.select(selectCoursesError);
    this.store.dispatch(loadCourses());
    console.log('HomeComponent initialised — courses loaded');
  }

  ngOnDestroy() {
    console.log('HomeComponent destroyed');
  }
}