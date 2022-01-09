import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { combine } from '@core';

@Component({
  selector: 'bl-add-sprint-dialog',
  templateUrl: './add-sprint-dialog.component.html',
  styleUrls: ['./add-sprint-dialog.component.scss']
})
export class AddSprintDialogComponent {

  readonly vm$ = combine([
    of("add-sprint-dialog")
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
    AddSprintDialogComponent
  ],
  exports: [
    AddSprintDialogComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class AddSprintDialogModule { }
