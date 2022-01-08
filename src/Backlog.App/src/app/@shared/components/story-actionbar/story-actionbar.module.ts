import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryActionbarComponent } from './story-actionbar.component';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    StoryActionbarComponent
  ],
  exports: [
    StoryActionbarComponent
  ],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class StoryActionbarModule { }
