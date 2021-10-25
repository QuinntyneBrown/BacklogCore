import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentLayoutComponent } from './content-layout.component';
import { FooterModule } from '@shared/footer/footer.module';
import { HeaderModule } from '@shared/header/header.module';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



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
