import { Component, Inject, Input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { combineLatest, of, Subject } from 'rxjs';
import { map, startWith, switchMap, tap } from 'rxjs/operators';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SprintService, StoryService } from '@api';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'bl-add-sprint-dialog',
  templateUrl: './add-sprint-dialog.component.html',
  styleUrls: ['./add-sprint-dialog.component.scss']
})
export class AddSprintDialogComponent {

  private readonly _addStorySubject: Subject<{
    storyId: string,
    sprintId: string
  }> = new Subject();

  private readonly _addStory$ = this._addStorySubject.asObservable();

  readonly vm$ = combineLatest([
    of(this._storyId),
    this._sprintService.GetSprints(),
    this._addStory$.pipe(
      switchMap(params => this._sprintService.AddSprintStory(params)),
      tap(_ => this._dialogRef.close()),
      startWith(null)
    )
  ])
  .pipe(
    map(([storyId, sprints]) => ({ storyId, sprints }))
  );

  constructor(
    private readonly _dialogRef: MatDialogRef<AddSprintDialogComponent>,
    private readonly _storyService: StoryService,
    private readonly _sprintService: SprintService,
    @Inject(MAT_DIALOG_DATA) private readonly _storyId: string,
  ) {

  }

  onClick(storyId,sprintId) {
    this._addStorySubject.next({ sprintId, storyId });
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
    MatDialogModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class AddSprintDialogModule { }
