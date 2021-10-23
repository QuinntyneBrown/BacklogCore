import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateStoryRoutingModule } from './create-story-routing.module';
import { CreateStoryComponent } from './create-story.component';


@NgModule({
  declarations: [
    CreateStoryComponent
  ],
  imports: [
    CommonModule,
    CreateStoryRoutingModule
  ]
})
export class CreateStoryModule { }
