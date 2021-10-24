import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoriesComponent } from './stories.component';

const routes: Routes = [
  {
    path: '',
    component: StoriesComponent,
    children: [
      { path: '', redirectTo: 'landing', pathMatch: 'full' },
      { path: 'create', loadChildren: () => import('./story/story.module').then(m => m.StoryModule) },
      { path: 'edit/:storyId', loadChildren: () => import('./story/story.module').then(m => m.StoryModule) },
      { path: 'landing', loadChildren: () => import('./story-tips/story-tips.module').then(m => m.StoryTipsModule), data: { default: true } }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoriesRoutingModule { }
