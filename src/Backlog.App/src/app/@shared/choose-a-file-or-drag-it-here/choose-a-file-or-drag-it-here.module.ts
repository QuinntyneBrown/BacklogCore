import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChooseAFileOrDragItHereComponent } from './choose-a-file-or-drag-it-here.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    ChooseAFileOrDragItHereComponent
  ],
  exports: [
    ChooseAFileOrDragItHereComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ]
})
export class ChooseAFileOrDragItHereModule { }
