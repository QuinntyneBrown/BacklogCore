import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDependencyRelationshipDialogComponent } from './add-dependency-relationship-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '@shared/atoms/title/title.module';
import { TitleBarModule } from '@shared/atoms/title-bar/title-bar.module';

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
    MatFormFieldModule,
    MatAutocompleteModule,
    MatInputModule,
    ReactiveFormsModule
  ]
})
export class AddDependencyRelationshipDialogModule { }
