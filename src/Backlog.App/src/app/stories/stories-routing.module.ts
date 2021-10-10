import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryListComponent } from './story-list/story-list.component';
import { StoryComponent } from './story/story.component';

const routes: Routes = [
  { path: '', component: StoryListComponent },
  { path: ':storyId', component: StoryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoriesRoutingModule { }
