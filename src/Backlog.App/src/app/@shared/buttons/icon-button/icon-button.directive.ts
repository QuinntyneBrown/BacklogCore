import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[bl-icon-button]'
})
export class IconButtonDirective {

  constructor(
    elementRef: ElementRef
  ) {
    (elementRef.nativeElement as HTMLElement).classList.add('bl-icon-button');
  }

}
