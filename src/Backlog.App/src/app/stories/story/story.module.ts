import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryRoutingModule } from './story-routing.module';
import { StoryComponent } from './story.component';
import { StoryControlModule } from '@shared/story-control/story-control.module';
import { StoryActionbarModule } from '@shared/story-actionbar/story-actionbar.module';
import { ButtonModule } from '@shared/buttons/button';
import { ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '@shared/title/title.module';
import { MatDialogModule } from '@angular/material/dialog';
import { AddSkillRequirementDialogModule } from '@shared/dialogs/add-skill-requirement-dialog';
import { AddDependencyRelationshipDialogModule } from '@shared/dialogs/add-dependency-relationship-dialog';


@NgModule({
  declarations: [
    StoryComponent
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    StoryControlModule,
    StoryActionbarModule,
    ButtonModule,
    ReactiveFormsModule,
    TitleModule,
    MatDialogModule,
    AddSkillRequirementDialogModule,
    AddDependencyRelationshipDialogModule
  ]
})
export class StoryModule { }
