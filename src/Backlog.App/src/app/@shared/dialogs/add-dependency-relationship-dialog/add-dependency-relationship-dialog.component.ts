import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Story, StoryService } from '@api';
import { Destroyable } from '@core';
import { BehaviorSubject, combineLatest, Observable, of } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'bl-add-dependency-relationship-dialog',
  templateUrl: './add-dependency-relationship-dialog.component.html',
  styleUrls: ['./add-dependency-relationship-dialog.component.scss']
})
export class AddDependencyRelationshipDialogComponent extends Destroyable {

  public searchControl = new FormControl(null,[Validators.required]);

  public readonly story$: BehaviorSubject<Story> = new BehaviorSubject(null);

  public readonly stories$: BehaviorSubject<Story[]> = new BehaviorSubject([]);

  constructor(
    @Inject(MAT_DIALOG_DATA) _story: Story,
    private readonly _storyService: StoryService,
    private readonly _dialogRef: MatDialogRef<AddDependencyRelationshipDialogComponent>
  ) {
    super();
    this.story$.next(_story);
  }

  filteredOptions: Observable<Story[]> = this.searchControl.valueChanges.pipe(
    startWith(""),
    map(value => (typeof value === "string" ? value : value && value.name)),
    switchMap(name => (name ? this._storyService.search({ query: name }) : of([])))
  )

  public storySelected($event: MatAutocompleteSelectedEvent) {
    var stories = this.stories$.value;

    const index = stories.map(x => x.name).indexOf($event.option.value.name);

    if(index == -1) {
      stories.push($event.option.value);
    } else {
      stories.splice(index,1);
    }

    this.stories$.next(stories);

    this.searchControl.reset();
  }

  public displayWith = value => value?.name;
}
