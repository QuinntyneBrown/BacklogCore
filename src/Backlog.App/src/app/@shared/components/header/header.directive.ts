import { Directive, ElementRef } from '@angular/core';
import { ClassListAccessor } from '@core/class-list-accessor';

@Directive({
  selector: '[bl-header]'
})
export class HeaderDirective extends ClassListAccessor {

  constructor(
    public readonly elementRef: ElementRef
  ) {
    super();
    this.classList.add('bl-header');
  }

  public close() {

  }
}
