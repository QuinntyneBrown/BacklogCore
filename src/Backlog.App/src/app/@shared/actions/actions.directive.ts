import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-actions]'
})
export class ActionsDirective {

  constructor(
    elementRef: ElementRef
  ) {
    (elementRef.nativeElement as HTMLElement).classList.add("bl-actions");
  }

}
