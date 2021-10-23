import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Destroyable } from '@core';

@Component({
  selector: 'bl-story-dialog',
  templateUrl: './story-dialog.component.html',
  styleUrls: ['./story-dialog.component.scss']
})
export class StoryDialogComponent extends Destroyable {

  constructor(
    private readonly _dialogRef: MatDialogRef<StoryDialogComponent>
  ) {
    super();
  }
}
