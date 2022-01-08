import { Directive, ElementRef } from '@angular/core';


@Directive({
  selector: '[bl-header]',
  host: {
    class:'bl-header'
  }
})
export class HeaderDirective { }
