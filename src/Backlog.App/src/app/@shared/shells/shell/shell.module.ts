import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '@shared/header/header.module';
import { MatIconModule } from '@angular/material/icon';
import { FooterModule } from '@shared/footer/footer.module';
import { ActionsModule } from '@shared/actions/actions.module';
import { MatSidenavModule } from '@angular/material/sidenav';


@NgModule({
  declarations: [
    ShellComponent
  ],
  imports: [
    CommonModule,
    ActionsModule,
    RouterModule,
    HeaderModule,
    MatIconModule,
    FooterModule,
    MatSidenavModule
  ]
})
export class ShellModule { }
