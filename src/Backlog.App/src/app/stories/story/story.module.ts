import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryRoutingModule } from './story-routing.module';
import { StoryComponent } from '../story/story.component';
import { ButtonModule } from '@shared/buttons/button/button.module';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { TitleFormFieldModule } from '@shared/form-fields';
import { TextareaModule } from '@shared/textarea';
import { MatDialogModule } from '@angular/material/dialog';
import { IconButtonModule } from '@shared/buttons/icon-button';
import { StoryControlModule } from '../story-control/story-control.module';
import { StoryActionbarModule } from '../story-actionbar/story-actionbar.module';

@NgModule({
  declarations: [
    StoryComponent
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
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
export class StoryModule { }
