import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { BoardRoutingModule } from './board-routing.module';
import { BoardComponent, TranslateStatusPipe } from './board.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BoardCardModule } from '@shared';


@NgModule({
  declarations: [
    BoardComponent,
    TranslateStatusPipe
  ],
  imports: [
    CommonModule,
    BoardRoutingModule,
    ReactiveFormsModule,
    DragDropModule,
    BoardCardModule
  ]
})
export class BoardModule { }
