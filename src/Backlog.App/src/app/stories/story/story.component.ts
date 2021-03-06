import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SprintService, StoryDto, StoryService } from '@api';
import { Destroyable } from '@core';
import { AddSprintDialogComponent, FileUploadDialogComponent } from '@shared/components/dialogs';
import { AddDependencyRelationshipDialogComponent } from '@shared/components/dialogs/add-dependency-relationship-dialog';
import { AddSkillRequirementDialogComponent } from '@shared/components/dialogs/add-skill-requirement-dialog';
import { BehaviorSubject, combineLatest, of, Subject } from 'rxjs';
import { map, pluck, startWith, switchAll, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss']
})
export class StoryComponent extends Destroyable  {
  readonly createAnotherControl = new FormControl(null, []);

  private readonly _addSprintSubject: Subject<string> = new Subject();

  private readonly _addSprint$ = this._addSprintSubject.asObservable();

  private readonly _refreshSubject: BehaviorSubject<void> = new BehaviorSubject(null);

  private readonly _refresh$ = this._refreshSubject;


  vm$ = combineLatest([
    this._activatedRoute.paramMap,
    this._addSprint$.pipe(
      switchMap(storyId => {
        return this._dialog
        .open(AddSprintDialogComponent, { 
          data: storyId
        })
        .afterClosed()
        .pipe(
          tap(_ => this._refreshSubject.next())
        )
      }),
      startWith(null)
    ),
    this._refresh$
  ])
  .pipe(
    map(([paramMap]) => paramMap.get("storyId")),
    switchMap(storyId => combineLatest(
      [ 
        storyId ? this._storyService.GetStoryById(storyId).pipe(pluck("story")) : of({ }),
        storyId ? this._sprintService.GetSprintsByStoryId(storyId).pipe(pluck("sprints")): of([])
      ])),
    map(([story, sprints ]) => {
      const storyControl = new FormControl(story,[Validators.required]);

      return {
        story,
        storyControl,
        sprints
      };
    })
  )

  constructor(
    private readonly _storyService: StoryService,
    private readonly _sprintService: SprintService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _dialog: MatDialog
  ) {
    super();

  }

  save(story: StoryDto) {
    const obs$ = story.storyId
    ? this._storyService.UpdateStory({ story })
    : this._storyService.CreateStory({ story });

    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => {
        if(!this.createAnotherControl.value) {
          this._router.navigate(['/','stories'])
        }

      })
    ).subscribe();
  }

  handleAddDependencyRelationshipClick(story: StoryDto) {
    this._dialog
    .open(AddDependencyRelationshipDialogComponent, {
      panelClass: 'g-dialog-panel',
      data: story
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe();
  }

  handleAddSkillRequirementClick(story: StoryDto) {
    this._dialog
    .open(AddSkillRequirementDialogComponent, {
      panelClass: 'g-dialog-panel',
      data: story
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe();
  }

  handleFileUploadClick(story: StoryDto) {
    this._dialog.open(FileUploadDialogComponent, {
      panelClass: 'g-dialog-panel',
      width:'100%',
      maxWidth: '600px'
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  onAddSprint(storyId: string) {
    this._addSprintSubject.next(storyId);
  }
}
