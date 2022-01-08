import { Directive } from '@angular/core';

@Directive({
  selector: '[blPill]',
  host: {
    class:'bl-pill'
  }
})
export class PillDirective { }
