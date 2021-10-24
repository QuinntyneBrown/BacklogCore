import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchDialogComponent } from './search-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { ButtonModule } from '@shared/buttons/button';
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    SearchDialogComponent
  ],
  exports: [
    SearchDialogComponent
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    TitleModule,
    MatIconModule,
    MatButtonModule,
    TitleBarModule,
    ButtonModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule
  ]
})
export class SearchDialogModule { }
