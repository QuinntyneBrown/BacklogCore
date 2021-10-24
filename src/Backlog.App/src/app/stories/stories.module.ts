import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoriesComponent } from './stories.component';
import { TwoColumnLayoutModule } from '@shared/two-column-layout/two-column-layout.module';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    StoriesComponent
  ],
  imports: [
    CommonModule,
    TwoColumnLayoutModule,
    StoriesRoutingModule,
    TitleModule,
    MatIconModule
  ]
})
export class StoriesModule { }
