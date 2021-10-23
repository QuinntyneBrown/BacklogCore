import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryActionbarComponent } from './story-actionbar.component';
import { MatIconModule } from '@angular/material/icon';
import { ButtonModule } from '@shared/buttons/button';
import { IconButtonModule } from '@shared/buttons/icon-button';



@NgModule({
  declarations: [
    StoryActionbarComponent
  ],
  exports: [
    StoryActionbarComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ButtonModule,
    IconButtonModule
  ]
})
export class StoryActionbarModule { }
