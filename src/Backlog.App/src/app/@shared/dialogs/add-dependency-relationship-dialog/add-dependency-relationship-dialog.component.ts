import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Story, StoryService } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'bl-add-dependency-relationship-dialog',
  templateUrl: './add-dependency-relationship-dialog.component.html',
  styleUrls: ['./add-dependency-relationship-dialog.component.scss']
})
export class AddDependencyRelationshipDialogComponent extends Destroyable {

  private readonly _story$: BehaviorSubject<Story> = new BehaviorSubject(null);

  public vm$ = combineLatest([this._story$, this._storyService.get()])
  .pipe(
    map(([story, stories]) => {
      const form = new FormGroup({
        dependsOn: new FormControl([],[])
      })
      return {
        form
      };
    })
  )

  constructor(
    @Inject(MAT_DIALOG_DATA) _story: Story,
    private readonly _storyService: StoryService,
    private readonly _dialogRef: MatDialogRef<AddDependencyRelationshipDialogComponent>
  ) {
    super();
    this._story$.next(_story);
  }

}
