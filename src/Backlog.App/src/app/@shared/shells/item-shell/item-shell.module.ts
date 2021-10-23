import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemShellComponent } from './item-shell.component';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '@shared/header/header.module';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    ItemShellComponent
  ],
  exports: [
    ItemShellComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    MatIconModule
  ]
})
export class ItemShellModule { }
