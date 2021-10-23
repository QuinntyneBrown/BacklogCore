import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconButtonDirective } from './icon-button.directive';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    IconButtonDirective
  ],
  exports: [
    IconButtonDirective
  ],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class IconButtonModule { }
