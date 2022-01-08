import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Story, StoryService } from '@api';
import { Destroyable } from '@core';
//import { StoriesFeatureService } from '@core/feature-services/stories-feature.service';
import { FileUploadDialogComponent } from '@shared/components/dialogs';
import { AddDependencyRelationshipDialogComponent } from '@shared/components/dialogs/add-dependency-relationship-dialog';
import { AddSkillRequirementDialogComponent } from '@shared/components/dialogs/add-skill-requirement-dialog';
import { BehaviorSubject, of } from 'rxjs';
import { map, startWith, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss']
})
export class StoryComponent extends Destroyable  {

  private readonly _refresh$ = new BehaviorSubject(null);

  public readonly createAnotherControl = new FormControl(null, []);

  public vm$ = this._activatedRoute
  .paramMap
  .pipe(
    map(paramMap => paramMap.get("storyId")),
    //switchMap(storyId => this._storiesFeatureService.storiesUpdated$.pipe(map(_ => storyId), startWith(storyId))),
    switchMap(storyId => {
      return storyId
      ? this._storyService.getById({ storyId })
      : of({ })
    }),
    map((story: Story) => {
      const storyControl = new FormControl(story,[Validators.required]);
      return {
        storyControl
      };
    })
  )
  constructor(
    private readonly _storyService: StoryService,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    //private readonly _storiesFeatureService: StoriesFeatureService,
    private readonly _dialog: MatDialog
  ) {
    super();

  }

  public save(story: Story) {

    const obs$ = story.storyId
    ? this._storyService.update({ story })
    : this._storyService.create({ story });

    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => {
        //this._storiesFeatureService.storiesUpdated$.next();

        if(!this.createAnotherControl.value) {
          this._router.navigate(['/','stories'])
        }

      })
    ).subscribe();
  }

  public handleAddDependencyRelationshipClick(story: Story) {
    this._dialog
    .open(AddDependencyRelationshipDialogComponent, {
      panelClass: 'g-dialog-panel',
      data: story
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$),
      tap(result => {
        if(result) {
          //this._storiesFeatureService.storiesUpdated$.next();
        }
      })
    )
    .subscribe();
  }

  public handleAddSkillRequirementClick(story: Story) {
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

  public handleFileUploadClick(story: Story) {
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
}
