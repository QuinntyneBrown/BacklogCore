import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TwoColumnLayoutComponent } from './two-column-layout.component';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '@shared/header/header.module';
import { MatIconModule } from '@angular/material/icon';
import { FooterModule } from '@shared/footer/footer.module';



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
    FooterModule
  ]
})
export class TwoColumnLayoutModule { }
