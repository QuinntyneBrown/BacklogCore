import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSkillRequirementDialogComponent } from './add-skill-requirement-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { TitleModule } from '@shared/atoms/title/title.module';
import { TitleBarModule } from '@shared/atoms/title-bar/title-bar.module';

@NgModule({
  declarations: [
    AddSkillRequirementDialogComponent
  ],
  exports: [
    AddSkillRequirementDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    TitleModule,
    MatIconModule,
    MatButtonModule,
    TitleBarModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule
  ]
})
export class AddSkillRequirementDialogModule { }
