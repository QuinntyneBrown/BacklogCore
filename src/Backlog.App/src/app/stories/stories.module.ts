import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoriesComponent } from './stories.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { SearchStoriesControlModule, SearchStoriesResultsModule } from '@shared';
import { ReactiveFormsModule } from '@angular/forms';
import { TwoColumnLayoutModule } from '@shared/components/two-column-layout/two-column-layout.module';
import { TitleModule } from '@shared/atoms/title/title.module';
import { TitleBarModule } from '@shared/atoms/title-bar/title-bar.module';


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
