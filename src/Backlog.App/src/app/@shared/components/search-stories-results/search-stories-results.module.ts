import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchStoriesResultsComponent } from './search-stories-results.component';



@NgModule({
  declarations: [
    SearchStoriesResultsComponent
  ],
  exports: [
    SearchStoriesResultsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SearchStoriesResultsModule { }
