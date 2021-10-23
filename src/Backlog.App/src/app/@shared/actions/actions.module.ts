import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionsDirective } from './actions.directive';



@NgModule({
  declarations: [
    ActionsDirective
  ],
  exports: [
    ActionsDirective
  ],
  imports: [
    CommonModule
  ]
})
export class ActionsModule { }
