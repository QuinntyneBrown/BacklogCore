import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditStoryRoutingModule } from './edit-story-routing.module';
import { EditStoryComponent } from './edit-story.component';


@NgModule({
  declarations: [
    EditStoryComponent
  ],
  imports: [
    CommonModule,
    EditStoryRoutingModule
  ]
})
export class EditStoryModule { }
