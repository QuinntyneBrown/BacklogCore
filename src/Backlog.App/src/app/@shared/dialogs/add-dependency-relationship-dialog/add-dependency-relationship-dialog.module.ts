import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDependencyRelationshipDialogComponent } from './add-dependency-relationship-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { ButtonModule } from '@shared/buttons/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AddDependencyRelationshipDialogComponent
  ],
  exports: [
    AddDependencyRelationshipDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    TitleModule,
    MatIconModule,
    MatButtonModule,
    TitleBarModule,
    ButtonModule,
    MatFormFieldModule,
    MatAutocompleteModule,
    MatInputModule,
    ReactiveFormsModule
  ]
})
export class AddDependencyRelationshipDialogModule { }
