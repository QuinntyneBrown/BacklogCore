import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StoryDto, StoryService } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-add-skill-requirement-dialog',
  templateUrl: './add-skill-requirement-dialog.component.html',
  styleUrls: ['./add-skill-requirement-dialog.component.scss']
})
export class AddSkillRequirementDialogComponent extends Destroyable {

  private _story$: BehaviorSubject<StoryDto> = new BehaviorSubject(null);

  public vm$ = this._story$
  .pipe(
    map(story => {
      const form = new FormGroup({
        storyId: new FormControl(story.storyId,[Validators.required]),
        technology: new FormControl(null,[Validators.required]),
        competencyLevel: new FormControl(null, [Validators.required])
      })
      return {
        form
      };
    })
  )

  public competencyLevels: string[] = [
    "Basic",
    "Capable",
    "Accomplished",
    "Authoritative"
  ];

  public technologies: string[] = [
    "Angular",
    "Asp.Net Core",
    "PostgresSQL",
    "AWS",
    "Sass",
    "HTML",
    "Domain Driven Design",
    "UI Architecture"
  ];

  constructor(
    @Inject(MAT_DIALOG_DATA) _story: StoryDto,
    private readonly _storyService: StoryService,
    private readonly _dialogRef: MatDialogRef<AddSkillRequirementDialogComponent>
  ) {
    super();
    this._story$.next(_story);
  }

  public save(options: { storyId: string, competencyLevel: string, technology: string}) {
    this._storyService
    .AddStorySkillRequirement(options)
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => this._dialogRef.close(true))
    ).subscribe();
  }
}
