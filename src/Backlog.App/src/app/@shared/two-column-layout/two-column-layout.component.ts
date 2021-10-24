import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Destroyable } from '@core';
import { classListAccessorMixin } from '@core/class-list-accessor';
import { filter, map, startWith, switchMap, tap } from 'rxjs/operators';

const DEFAULT_CLASS: string = "two-column-layout--default";

@Component({
  selector: 'bl-two-column-layout',
  templateUrl: './two-column-layout.component.html',
  styleUrls: ['./two-column-layout.component.scss']
})
export class TwoColumnLayoutComponent extends classListAccessorMixin(Destroyable) {

  public vm$ = this._router
  .events
  .pipe(
    filter(e => e  instanceof  NavigationEnd),
    startWith(true),
    switchMap(_ => this._activatedRoute.firstChild.data),
    map(data => ({ default: data.default })),
    tap(data => {
      if(data.default) {
        if(!this.classList.contains(DEFAULT_CLASS)) {
          this.classList.add(DEFAULT_CLASS);
        }
      } else {
        this.classList.remove(DEFAULT_CLASS);
      }
    })
  )



  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    public readonly elementRef: ElementRef
  ) {
    super();
  }
}
