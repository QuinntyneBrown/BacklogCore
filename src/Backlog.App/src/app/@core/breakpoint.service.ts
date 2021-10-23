import { BreakpointObserver } from '@angular/cdk/layout';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BreakpointService {

  public isGreaterThanMedium$: Observable<boolean> = this._breakpointObserver
  .observe("(min-width: 992px)")
  .pipe(map(breakpointState => breakpointState.matches));

  public isLessThanMedium$: Observable<boolean> = this._breakpointObserver
  .observe("(max-width: 992px)")
  .pipe(map(breakpointState => breakpointState.matches));

  constructor(
    private readonly _breakpointObserver: BreakpointObserver
  ) { }
}
