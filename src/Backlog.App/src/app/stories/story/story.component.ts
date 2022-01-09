import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SprintService, Story, StoryService } from '@api';
import { Destroyable } from '@core';
import { FileUploadDialogComponent } from '@shared/components/dialogs';
import { AddDependencyRelationshipDialogComponent } from '@shared/components/dialogs/add-dependency-relationship-dialog';
import { AddSkillRequirementDialogComponent } from '@shared/components/dialogs/add-skill-requirement-dialog';
import { combineLatest, of, Subject } from 'rxjs';
import { map, startWith, switchAll, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss']
})
export class StoryComponent extends Destroyable  {
  readonly createAnotherControl = new FormControl(null, []);


  private readonly _addSprintSubject: Subject<string> = new Subject();

  private readonly _addSprint$ = this._addSprintSubject.asObservable();

  vm$ = combineLatest([
    this._activatedRoute.paramMap,
    this._addSprint$.pipe(
      switchMap(storyId => {

        // open dialog , erc...
        return of(null)
      }),
      startWith(null)
    )
  ])
  .pipe(
    map(([paramMap]) => paramMap.get("storyId")),
    switchMap(storyId => combineLatest(
      [ 
        storyId 
        ? this._storyService.getById({ storyId })
        : of({ }),
        this._sprintService.getByStoryId({ storyId })
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

  save(story: Story) {
    const obs$ = story.storyId
    ? this._storyService.update({ story })
    : this._storyService.create({ story });

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

  handleAddDependencyRelationshipClick(story: Story) {
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

  handleAddSkillRequirementClick(story: Story) {
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

  handleFileUploadClick(story: Story) {
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
