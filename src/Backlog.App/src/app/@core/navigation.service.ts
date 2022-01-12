import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  constructor(private readonly _router: Router) {}

  loginUrl = '/login';

  lastPath: string = '';

  defaultPath = '/';

  setLoginUrl(value: string): void {
    this.loginUrl = value;
  }

  setDefaultUrl(value: string): void {
    this.defaultPath = value;
  }

  redirectToLogin(): void {
    this._router.navigate([this.loginUrl]);
  }

  redirectToPublicDefault(): void {    
    this._router.navigate(['']);
  }

  redirectPreLogin(): void {
    if (this.lastPath && this.lastPath !== this.loginUrl) {
      window.location.href = this.lastPath;
      this.lastPath = '';
    } else {
      this._router.navigate([this.defaultPath]);
      window.location.href = this.defaultPath;
    }
  }
}
