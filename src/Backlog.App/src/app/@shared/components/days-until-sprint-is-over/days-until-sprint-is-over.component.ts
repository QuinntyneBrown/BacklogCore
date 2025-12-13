import { Component, Input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs/operators';
import { SprintStore } from '@core/stores/sprint.store';

@Component({
  selector: 'bl-days-until-sprint-is-over',
  templateUrl: './days-until-sprint-is-over.component.html',
  styleUrls: ['./days-until-sprint-is-over.component.scss']
})
export class DaysUntilSprintIsOverComponent {

  readonly vm$ = this._sprintStore
  .current()
  .pipe(
    map(sprint => {
      if(!sprint?.end) {
        return {
          days: 0
        }
      }
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
    private readonly _sprintStore: SprintStore
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
