import { Component, Input, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Story } from '@api';

@Component({
  selector: 'bl-board-card',
  templateUrl: './board-card.component.html',
  styleUrls: ['./board-card.component.scss']
})
export class BoardCardComponent  {
  @Input() story!: Story;
}

@NgModule({
  declarations: [
    BoardCardComponent
  ],
  exports: [
    BoardCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class BoardCardModule { }
