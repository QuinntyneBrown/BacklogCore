import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitleFormFieldDirective } from './title-form-field.directive';



@NgModule({
  declarations: [
    TitleFormFieldDirective
  ],
  exports: [
    TitleFormFieldDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TitleFormFieldModule { }
