import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav.component';
import { HeaderModule } from '@shared/header/header.module';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    SidenavComponent
  ],
  exports: [
    SidenavComponent
  ],
  imports: [
    CommonModule,
    HeaderModule,
    MatIconModule
  ]
})
export class SidenavModule { }
