import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClassListAccessor } from '@core/class-list-accessor';
import { map, tap } from 'rxjs/operators';


@Component({
  selector: 'bl-two-column-layout',
  templateUrl: './two-column-layout.component.html',
  styleUrls: ['./two-column-layout.component.scss']
})
export class TwoColumnLayoutComponent extends ClassListAccessor {

  public vm$ = this._activatedRoute
  .firstChild
  .data
  .pipe(
    map(data => ({ default: data.default })),
    tap(data => {
      if(data.default) {
        this.classList.add('two-column-layout--default');
      }
    })
  )

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    public readonly elementRef: ElementRef
  ) {
    super();
  }
}
