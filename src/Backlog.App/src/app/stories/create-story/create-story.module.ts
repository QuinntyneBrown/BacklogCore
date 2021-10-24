import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateStoryRoutingModule } from './create-story-routing.module';
import { CreateStoryComponent } from './create-story.component';
import { StoryControlModule } from '@shared/story-control/story-control.module';
import { StoryActionbarModule } from '@shared/story-actionbar/story-actionbar.module';


@NgModule({
  declarations: [
    CreateStoryComponent
  ],
  imports: [
    CommonModule,
    CreateStoryRoutingModule,
    StoryControlModule,
    StoryActionbarModule
  ]
})
export class CreateStoryModule { }
