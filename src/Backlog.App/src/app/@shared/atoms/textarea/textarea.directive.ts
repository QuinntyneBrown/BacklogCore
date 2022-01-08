import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-textarea]'
})
export class TextareaDirective {

  constructor(
    elementRef: ElementRef
  ) {
    (elementRef.nativeElement as HTMLElement).classList.add('bl-textarea');
  }

}
