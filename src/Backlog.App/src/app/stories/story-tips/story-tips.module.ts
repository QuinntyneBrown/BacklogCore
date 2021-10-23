import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoryTipsRoutingModule } from './story-tips-routing.module';
import { StoryTipsComponent } from './story-tips.component';


@NgModule({
  declarations: [
    StoryTipsComponent
  ],
  imports: [
    CommonModule,
    StoryTipsRoutingModule
  ]
})
export class StoryTipsModule { }
