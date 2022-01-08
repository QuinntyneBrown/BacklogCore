import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TwoColumnLayoutComponent } from './two-column-layout.component';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '@shared/components/header/header.module';
import { MatIconModule } from '@angular/material/icon';
import { FooterModule } from '@shared/components/footer/footer.module';
import { ContentLayoutModule } from '@shared/components/content-layout';



@NgModule({
  declarations: [
    TwoColumnLayoutComponent
  ],
  exports: [
    TwoColumnLayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    MatIconModule,
    FooterModule,
    ContentLayoutModule
  ]
})
export class TwoColumnLayoutModule { }
