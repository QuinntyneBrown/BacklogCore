import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryControlComponent } from './story-control.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextareaModule } from '@shared/textarea';
import { TitleFormFieldModule } from '@shared/form-fields';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { PillModule } from '@shared/pills';
import { MatIconModule } from '@angular/material/icon';
import { TitleModule } from '@shared/title/title.module';


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
    PillModule,
    MatIconModule,
    TitleModule
  ]
})
export class StoryControlModule { }
