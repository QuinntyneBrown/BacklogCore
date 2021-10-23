import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitleDirective } from './title.directive';



@NgModule({
  declarations: [
    TitleDirective
  ],
  exports: [
    TitleDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TitleModule { }
