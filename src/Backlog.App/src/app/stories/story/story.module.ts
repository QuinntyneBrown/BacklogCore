import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryRoutingModule } from './story-routing.module';
import { StoryComponent } from './story.component';
import { StoryControlModule } from '@shared/components/story-control/story-control.module';
import { StoryActionbarModule } from '@shared/components/story-actionbar/story-actionbar.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { AddSkillRequirementDialogModule } from '@shared/components/dialogs/add-skill-requirement-dialog';
import { AddDependencyRelationshipDialogModule } from '@shared/components/dialogs/add-dependency-relationship-dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FileUploadDialogModule } from '@shared';
import { TitleModule } from '@shared/atoms/title/title.module';

@NgModule({
  declarations: [
    StoryComponent
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    StoryControlModule,
    StoryActionbarModule,
    ReactiveFormsModule,
    TitleModule,
    MatDialogModule,
    AddSkillRequirementDialogModule,
    AddDependencyRelationshipDialogModule,
    FileUploadDialogModule,
    MatCheckboxModule
  ]
})
export class StoryModule { }
