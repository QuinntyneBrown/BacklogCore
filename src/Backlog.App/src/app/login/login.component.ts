import { Component } from '@angular/core';
import { combineLatest, defer, Subject } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '@api';


type Credentials = {
  username: string,
  password: string
};

@Component({
  selector: 'bl-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  private readonly _loginSubject: Subject<Credentials> = new Subject();

  readonly vm$ = combineLatest([
    this._loginSubject.pipe(
      switchMap(credentials => this._userService.Authenticate(credentials)),
      startWith(null)
    )
  ])
  .pipe(
    map(([name]) => {

      const form = new FormGroup({
        username: new FormControl(null,[Validators.required]),
        password: new FormControl(null, [Validators.required])
      });

      return {
        form
      }
    })
  );

  constructor(
    private readonly _userService: UserService
  ) {

  }

  onLogin(credentials: Credentials) {
    this._loginSubject.next(credentials);
  }
}
