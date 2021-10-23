import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextareaDirective } from './textarea.directive';



@NgModule({
  declarations: [
    TextareaDirective
  ],
  exports: [
    TextareaDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TextareaModule { }
