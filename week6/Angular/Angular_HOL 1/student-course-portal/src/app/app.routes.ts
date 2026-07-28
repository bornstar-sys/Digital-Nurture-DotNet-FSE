import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { EnrollmentForm } from './pages/enrollment-form/enrollment-form';
import { ReactiveEnrollmentForm } from './pages/reactive-enrollment-form/reactive-enrollment-form';
import { CourseDetail } from './pages/course-detail/course-detail';
import { StudentProfile } from './pages/student-profile/student-profile';
import { NotFound } from './pages/not-found/not-found';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'enroll', component: EnrollmentForm },
  { path: 'enroll-reactive', component: ReactiveEnrollmentForm },
  { path: 'courses/:id', component: CourseDetail },
  { path: 'profile', component: StudentProfile, canActivate: [AuthGuard] },
  { path: '**', component: NotFound }
];