import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoriesRoutingModule } from './stories-routing.module';
import { StoriesComponent } from './stories.component';
import { TwoColumnLayoutModule } from '@shared/two-column-layout/two-column-layout.module';
import { TitleModule } from '@shared/title/title.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TitleBarModule } from '@shared/title-bar/title-bar.module';
import { MatDialogModule } from '@angular/material/dialog';
import { SearchDialogModule } from '@shared/dialogs/search-dialog';


@NgModule({
  declarations: [
    StoriesComponent
  ],
  imports: [
    CommonModule,
    TwoColumnLayoutModule,
    StoriesRoutingModule,
    TitleModule,
    TitleBarModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    SearchDialogModule
  ]
})
export class StoriesModule { }
