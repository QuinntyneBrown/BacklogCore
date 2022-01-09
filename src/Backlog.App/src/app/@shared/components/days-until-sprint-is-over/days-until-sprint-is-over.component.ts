import { Component, Input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';
import { Sprint, SprintService } from '@api';

@Component({
  selector: 'bl-days-until-sprint-is-over',
  templateUrl: './days-until-sprint-is-over.component.html',
  styleUrls: ['./days-until-sprint-is-over.component.scss']
})
export class DaysUntilSprintIsOverComponent {

  readonly vm$ = this._sprintService
  .current()
  .pipe(
    map(sprint => {
      let dueDate = new Date(sprint.end) as any;
      let today = new Date() as any;
      const diffTime = Math.abs(today - dueDate);
      let days = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

      return {
        days
      }
    })
  )
  
  constructor(
    private readonly _sprintService: SprintService
  ) {

  }
}

@NgModule({
  declarations: [
    DaysUntilSprintIsOverComponent
  ],
  exports: [
    DaysUntilSprintIsOverComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class DaysUntilSprintIsOverModule { }
