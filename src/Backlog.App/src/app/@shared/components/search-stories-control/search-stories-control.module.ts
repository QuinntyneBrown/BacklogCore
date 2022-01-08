import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchStoriesControlComponent } from './search-stories-control.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    SearchStoriesControlComponent
  ],
  exports: [
    SearchStoriesControlComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class SearchStoriesControlModule { }
