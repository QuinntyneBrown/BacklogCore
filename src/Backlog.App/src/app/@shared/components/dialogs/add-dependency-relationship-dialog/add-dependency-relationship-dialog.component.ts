import { Component, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StoryDto, StoryService } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, pluck, startWith, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'bl-add-dependency-relationship-dialog',
  templateUrl: './add-dependency-relationship-dialog.component.html',
  styleUrls: ['./add-dependency-relationship-dialog.component.scss']
})
export class AddDependencyRelationshipDialogComponent extends Destroyable {

  public searchControl = new FormControl(null,[]);

  public readonly story$: BehaviorSubject<StoryDto> = new BehaviorSubject(null);

  public readonly stories$: BehaviorSubject<string[]> = new BehaviorSubject([]);

  constructor(
    @Inject(MAT_DIALOG_DATA) _story: StoryDto,
    private readonly _storyService: StoryService,
    private readonly _dialogRef: MatDialogRef<AddDependencyRelationshipDialogComponent>
  ) {
    super();
    this.stories$.next(_story.dependsOn);
    this.story$.next(_story);

  }

  filteredOptions: Observable<StoryDto[]> = this.searchControl.valueChanges.pipe(
    startWith(""),
    map(value => (typeof value === "string" ? value : value && value.name)),
    switchMap(name => (name ? this._storyService.SearchStories(name).pipe(
      pluck("stories")
    ) : of([])))
  )

  public storySelected($event: MatAutocompleteSelectedEvent) {
    var stories = this.stories$.value;

    const index = stories.indexOf($event.option.value.name);

    if(index == -1) {
      stories.push($event.option.value.name);
    } else {
      stories.splice(index,1);
    }

    this.stories$.next(stories);

    this.searchControl.reset();
  }

  public displayWith = value => value?.name;

  public save() {
    this._storyService.UpdateStoryDependsOn({ storyId: this.story$.value.storyId, dependsOn: this.stories$.value })
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => {
        this._dialogRef.close(true)
      })
    ).subscribe();
  }
}
