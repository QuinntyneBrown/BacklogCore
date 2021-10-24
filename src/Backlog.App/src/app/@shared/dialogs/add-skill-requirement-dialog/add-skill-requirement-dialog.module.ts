import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddSkillRequirementDialogComponent } from './add-skill-requirement-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { ButtonModule } from '@shared/buttons/button';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

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
    ButtonModule,
    MatSelectModule,
    ReactiveFormsModule,
    ButtonModule,
    MatInputModule,
    MatFormFieldModule
  ]
})
export class AddSkillRequirementDialogModule { }
