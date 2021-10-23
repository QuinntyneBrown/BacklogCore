import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoryListComponent } from './story-list/story-list.component';
import { ButtonModule } from '@shared/buttons/button/button.module';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { TitleFormFieldModule } from '@shared/form-fields';
import { TextareaModule } from '@shared/textarea';
import { StoryDialogComponent } from './story-dialog/story-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { IconButtonModule } from '@shared/buttons/icon-button';
import { StoryControlModule } from './story-control/story-control.module';
import { StoryActionbarModule } from './story-actionbar/story-actionbar.module';

@NgModule({
  declarations: [
    StoryListComponent,
    StoryDialogComponent
  ],
  imports: [
    CommonModule,
    StoriesRoutingModule,
    ButtonModule,
    IconButtonModule,
    TextareaModule,
    TitleModule,
    TitleBarModule,
    TitleFormFieldModule,
    MatIconModule,
    MatDialogModule,
    StoryControlModule,
    StoryActionbarModule

  ]
})
export class StoriesModule { }
