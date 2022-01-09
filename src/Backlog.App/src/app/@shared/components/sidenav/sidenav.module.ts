import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav.component';
import { HeaderModule } from '@shared/components/header/header.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { DaysUntilSprintIsOverModule } from '../days-until-sprint-is-over/days-until-sprint-is-over.component';



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
    MatIconModule,
    MatButtonModule,
    RouterModule,
    DaysUntilSprintIsOverModule
  ]
})
export class SidenavModule { }
