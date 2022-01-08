import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitleGroupComponent } from './title-group.component';
import { SubHeadingDirective } from './sub-heading.directive';
import { HeadingDirective } from './heading.directive';



@NgModule({
  declarations: [
    TitleGroupComponent,
    SubHeadingDirective,
    HeadingDirective
  ],
  exports: [
    TitleGroupComponent,
    SubHeadingDirective,
    HeadingDirective
  ],
  imports: [
    CommonModule
  ]
})
export class TitleGroupModule { }
