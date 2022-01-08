import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';
import { SprintService, StoryService } from '@api';


@Component({
  selector: 'bl-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent {

  readonly vm$ = combine([
    of("board")
  ])
  .pipe(
    map(([name]) => ({ name }))
  );

  constructor(
    private readonly _sprintService: SprintService,
    private readonly _storyService: StoryService
  ) {

  }
}
