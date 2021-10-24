import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDependencyRelationshipDialogComponent } from './add-dependency-relationship-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { ButtonModule } from '@shared/buttons/button';

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
    ButtonModule
  ]
})
export class AddDependencyRelationshipDialogModule { }
