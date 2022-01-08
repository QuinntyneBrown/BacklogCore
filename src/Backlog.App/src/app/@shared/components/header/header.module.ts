import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderDirective } from './header.directive';



@NgModule({
  declarations: [
    HeaderDirective
  ],
  exports: [
    HeaderDirective
  ],
  imports: [
    CommonModule
  ]
})
export class HeaderModule { }
