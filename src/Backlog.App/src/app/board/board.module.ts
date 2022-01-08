import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { BoardRoutingModule } from './board-routing.module';
import { BoardComponent } from './board.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BoardComponent
  ],
  imports: [
    CommonModule,
    BoardRoutingModule,
    ReactiveFormsModule,
    DragDropModule
  ]
})
export class BoardModule { }
