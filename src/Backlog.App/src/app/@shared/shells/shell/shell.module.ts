import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { HeaderModule } from '@shared/components/header/header.module';
import { FooterModule } from '@shared/components/footer/footer.module';
import { SidenavModule } from '@shared/components/sidenav';
import { NavbarModule } from '@shared/components/navbar';



@NgModule({
  declarations: [
    ShellComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    MatIconModule,
    FooterModule,
    MatIconModule,
    MatSidenavModule,
    SidenavModule,
    NavbarModule
  ]
})
export class ShellModule { }
