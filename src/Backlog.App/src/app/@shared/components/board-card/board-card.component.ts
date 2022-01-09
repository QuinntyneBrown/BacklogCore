import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';

@Component({
  selector: 'bl-board-card',
  templateUrl: './board-card.component.html',
  styleUrls: ['./board-card.component.scss']
})
export class BoardCardComponent {

  readonly vm$ = combine([
    of("board-card")
  ])
  .pipe(
    map(([name]) => ({ name }))
  );

  constructor(

  ) {

  }
}

@NgModule({
  declarations: [
    BoardCardComponent
  ],
  exports: [
    BoardCardComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class BoardCardModule { }
