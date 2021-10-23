import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-header]'
})
export class HeaderDirective {

  constructor(
    elementRef: ElementRef
  ) {
    (elementRef.nativeElement as HTMLElement).classList.add('bl-header');
  }

}
