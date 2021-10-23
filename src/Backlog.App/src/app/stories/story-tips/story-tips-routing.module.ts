import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryTipsComponent } from './story-tips.component';

const routes: Routes = [{ path: '', component: StoryTipsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoryTipsRoutingModule { }
