import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryControlComponent } from './story-control.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TextareaModule } from '@shared/atoms/textarea';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { TitleFormFieldModule } from '../form-fields/title-form-field/title-form-field.module';
import { PillModule } from '../pills/pill/pill.module';
import { TitleModule } from '@shared/atoms/title/title.module';


@NgModule({
  declarations: [StoryControlComponent],
  exports: [StoryControlComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
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

