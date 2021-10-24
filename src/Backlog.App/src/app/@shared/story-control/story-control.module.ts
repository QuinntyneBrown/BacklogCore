import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryControlComponent } from './story-control.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextareaModule } from '@shared/textarea';
import { TitleFormFieldModule } from '@shared/form-fields';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { PillModule } from '@shared/pills';

@NgModule({
  declarations: [StoryControlComponent],
  exports: [StoryControlComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TextareaModule,
    TitleFormFieldModule,
    MatFormFieldModule,
    MatInputModule,
    PillModule
  ]
})
export class StoryControlModule { }
