import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-title-form-field]'
})
export class TitleFormFieldDirective {

  constructor(
    elementRef: ElementRef
  ) {
    (elementRef.nativeElement as HTMLElement).classList.add("bl-title-form-field")
  }

}
