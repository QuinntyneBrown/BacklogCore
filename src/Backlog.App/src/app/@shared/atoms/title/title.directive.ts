import { Directive, ElementRef } from '@angular/core';
import { ClassListAccessor } from '@core/class-list-accessor';

@Directive({
  selector: '[bl-title]'
})
export class TitleDirective extends ClassListAccessor {
  constructor(public readonly elementRef: ElementRef) {
    super();
    this.classList.add('g-title');
  }
}
