import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoryListComponent } from './story-list/story-list.component';
import { StoryComponent } from './story/story.component';


@NgModule({
  declarations: [
    StoryListComponent,
    StoryComponent
  ],
  imports: [
    CommonModule,
    StoriesRoutingModule
  ]
})
export class StoriesModule { }
