import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoriesComponent } from './stories.component';
import { TwoColumnLayoutModule } from '@shared/two-column-layout/two-column-layout.module';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { MatDialogModule } from '@angular/material/dialog';
import { SearchStoriesControlModule, SearchStoriesResultsModule } from '@shared';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    StoriesComponent
  ],
  imports: [
    CommonModule,
    TwoColumnLayoutModule,
    StoriesRoutingModule,
    TitleModule,
    TitleBarModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    SearchStoriesControlModule,
    SearchStoriesResultsModule,
    ReactiveFormsModule
  ]
})
export class StoriesModule { }
