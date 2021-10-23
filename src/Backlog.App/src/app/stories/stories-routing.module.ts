import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoriesComponent } from './stories.component';

const routes: Routes = [
  {
    path: '',
    component: StoriesComponent,
    children: [
      { path: '', redirectTo: 'landing', pathMatch: 'full' },
      { path: 'create', loadChildren: () => import('./create-story/create-story.module').then(m => m.CreateStoryModule) },
      { path: 'edit/:storyId', loadChildren: () => import('./edit-story/edit-story.module').then(m => m.EditStoryModule) },
      { path: 'landing', loadChildren: () => import('./story-tips/story-tips.module').then(m => m.StoryTipsModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoriesRoutingModule { }
