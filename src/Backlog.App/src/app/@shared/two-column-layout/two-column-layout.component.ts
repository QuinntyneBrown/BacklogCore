import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Destroyable } from '@core';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-two-column-layout',
  templateUrl: './two-column-layout.component.html',
  styleUrls: ['./two-column-layout.component.scss']
})
export class TwoColumnLayoutComponent extends Destroyable {

  public vm$ = this._activatedRoute
  .firstChild
  .data
  .pipe(
    map(data => ({ default: data.default })),
    tap(data => {
      if(data.default) {
        (this._elementRef.nativeElement as HTMLElement).classList.add('two-column-layout--default');
      }
    })
  )

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _elementRef: ElementRef
  ) {
    super();
  }
}
