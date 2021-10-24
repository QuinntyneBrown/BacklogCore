import { Directive, ElementRef } from '@angular/core';
import { classListAccessorMixin } from '@core/class-list-accessor';

@Directive({
  selector: '[bl-pill]'
})
export class PillDirective extends classListAccessorMixin(class { }) {

  constructor(
    public readonly elementRef: ElementRef
  ) {
    super();
    this.classList.add("bl-pill")
  }

}
