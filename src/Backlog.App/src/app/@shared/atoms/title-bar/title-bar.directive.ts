import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-title-bar]'
})
export class TitleBarDirective {
  constructor(elementRef: ElementRef) {
    (elementRef.nativeElement as HTMLElement).classList.add('g-title-bar');
  }

}
