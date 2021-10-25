import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { StoryService } from '@api';
import { StoriesFeatureService } from '@core/feature-services/stories-feature.service';
import { BehaviorSubject, of } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'bl-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent  {

  private readonly _searchEnabled$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  private searchControl = new FormControl(null,[]);


  public vm$ = this._storiesFeatureService.storiesUpdated$
  .pipe(
    startWith(true),
    switchMap(_ => this._searchEnabled$),
    switchMap(searchEnabled => {
      return searchEnabled
      ? this.searchControl.valueChanges.pipe(
        startWith(""),
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
        query: this.searchControl.value
      };
    })
  )

  constructor(
    private readonly _storyService: StoryService,
    private readonly _storiesFeatureService: StoriesFeatureService
  ) { }

    public handleSearchClick() {
      this._searchEnabled$.next(true);
    }

    public handleCloseClick() {
      this._searchEnabled$.next(false);
    }

}
