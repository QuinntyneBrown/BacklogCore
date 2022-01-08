import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentLayoutComponent } from './content-layout.component';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FooterModule } from '../footer/footer.module';
import { HeaderModule } from '../header/header.module';



@NgModule({
  declarations: [
    ContentLayoutComponent
  ],
  exports: [
    ContentLayoutComponent
  ],
  imports: [
    CommonModule,
    FooterModule,
    HeaderModule,
    RouterModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class ContentLayoutModule { }
