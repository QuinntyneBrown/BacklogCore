import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PillDirective } from './pill.directive';


@NgModule({
  declarations: [
    PillDirective
  ],
  exports: [
    PillDirective
  ],
  imports: [
    CommonModule
  ]
})
export class PillModule { }
