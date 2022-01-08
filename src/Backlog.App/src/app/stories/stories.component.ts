import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { StoryService } from '@api';
import { BehaviorSubject, of } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'bl-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent  {

  private readonly _searchEnabled$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  private readonly _searchControl = new FormControl(null,[]);

  private readonly _refreshSubject: BehaviorSubject<void> = new BehaviorSubject(null);

  public vm$ = this._refreshSubject
  .pipe(
    startWith(true),
    switchMap(_ => this._searchEnabled$),
    switchMap(searchEnabled => {
      return searchEnabled
      ? this._searchControl.valueChanges.pipe(
        startWith(this._searchControl.value),
        switchMap(query => query ? this._storyService.search({ query }).pipe(
          map(stories => ([stories, searchEnabled]))
        )
        : of([[], searchEnabled]))
      )
      : this._storyService.get()
      .pipe(
        map(stories => ([stories, searchEnabled]))
      )
    }),
    map(([stories, searchEnabled]) => {
      return {
        stories,
        searchEnabled,
        query: this._searchControl.value
      };
    })
  )

  constructor(
    private readonly _storyService: StoryService
  ) { }

    public handleSearchClick() {
      this._searchEnabled$.next(true);
    }

    public handleCloseClick() {
      this._searchEnabled$.next(false);
    }

}
