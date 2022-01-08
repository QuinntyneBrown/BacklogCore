import { Directive } from '@angular/core';

@Directive({
  selector: '[blTitle]',
  host: {
    class:'bl-title'
  }
})
export class TitleDirective  { }
