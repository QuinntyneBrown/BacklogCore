import { Injectable } from '@angular/core';
import { LocalStorageService } from './local-storage.service';
import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { accessTokenKey, usernameKey } from './constants';
import { UserDto, UserService } from '@api';
import { combineLatest, Observable, of, ReplaySubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly _currentUserSubject: ReplaySubject<UserDto> = new ReplaySubject(1);

  currentUser$: Observable<UserDto> = this._currentUserSubject.asObservable();

  constructor(
    private readonly _localStorageService: LocalStorageService,
    private readonly _userService: UserService,
    
  ) {}

  public logout() {
    this._localStorageService.put({ name: accessTokenKey, value: null});
    this._localStorageService.put({ name: usernameKey, value: null });
  }

  tryToLogin(options: { username: string; password: string }) {
    return this._userService.Authenticate({ username: options.username, password: options.password })
    .pipe(
      tap(response => {
        this._localStorageService.put({ name: accessTokenKey, value: response.accessToken });
        this._localStorageService.put({ name: usernameKey, value: options.username});
      }),
      switchMap(_ => of({})),
      tap(x => this._currentUserSubject.next(x))
    );
  }

  tryToInitializeCurrentUser(): Observable<UserDto> {
    return combineLatest([this._userService.GetCurrent()])
    .pipe(
      map(([user]) => Object.assign(user)),
      tap(user => this._currentUserSubject.next(user)),
      catchError(_ => of(null))
    );
  }
}
