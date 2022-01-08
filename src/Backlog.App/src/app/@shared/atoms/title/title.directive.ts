import { Directive } from '@angular/core';

@Directive({
  selector: '[bl-title]',
  host: {
    class:'g-title'
  }
})
export class TitleDirective  { }
