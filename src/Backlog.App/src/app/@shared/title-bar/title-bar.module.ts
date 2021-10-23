import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitleBarDirective } from './title-bar.directive';



@NgModule({
  declarations: [
    TitleBarDirective
  ],
  exports: [
    TitleBarDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TitleBarModule { }
