import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadDialogComponent } from './file-upload-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ChooseAFileOrDragItHereModule } from '@shared/components/choose-a-file-or-drag-it-here/choose-a-file-or-drag-it-here.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { TitleModule } from '@shared/atoms/title/title.module';
import { TitleBarModule } from '@shared/atoms/title-bar/title-bar.module';



@NgModule({
  declarations: [
    FileUploadDialogComponent
  ],
  exports: [
    FileUploadDialogComponent
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
    MatFormFieldModule,
    ChooseAFileOrDragItHereModule
  ]
})
export class FileUploadDialogModule { }
