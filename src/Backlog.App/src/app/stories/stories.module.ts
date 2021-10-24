import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoriesComponent } from './stories.component';
import { TwoColumnLayoutModule } from '@shared/two-column-layout/two-column-layout.module';


@NgModule({
  declarations: [
    StoriesComponent
  ],
  imports: [
    CommonModule,
    TwoColumnLayoutModule,
    StoriesRoutingModule
  ]
})
export class StoriesModule { }
