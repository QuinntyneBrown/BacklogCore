import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryControlComponent } from './story-control.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextareaModule } from '@shared/textarea';
import { TitleFormFieldModule } from '@shared/form-fields';



@NgModule({
  declarations: [StoryControlComponent],
  exports: [StoryControlComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TextareaModule,
    TitleFormFieldModule
  ]
})
export class StoryControlModule { }
