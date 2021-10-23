import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-button]'
})
export class ButtonDirective {
  constructor(elementRef: ElementRef) {
    (elementRef.nativeElement as HTMLElement).classList.add('bl-button');
  }
}
