import { TestBed } from '@angular/core/testing';
import { AuthGuard } from './auth-guard';
import { provideRouter } from '@angular/router';

describe('AuthGuard', () => {
  let guard: AuthGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideRouter([])]
    });
    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should allow access when logged in', () => {
    guard.isLoggedIn = true;
    expect(guard.canActivate()).toBe(true);
  });
});