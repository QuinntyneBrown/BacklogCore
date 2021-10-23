import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-title]'
})
export class TitleDirective {
  constructor(elementRef: ElementRef) {
    (elementRef.nativeElement as HTMLElement).classList.add('g-title');
  }
}
