import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { StoryService } from '@api';
import { routeChanged$ } from '@core/route-changed';
import { BehaviorSubject, combineLatest, merge, of, Subject } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'bl-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent  {

  private readonly _searchEnabledSubject: Subject<boolean> = new Subject();

  private readonly _searchEnabled$ = this._searchEnabledSubject.asObservable();

  private readonly _refreshSubject: BehaviorSubject<void> = new BehaviorSubject(null);

  private readonly _refresh$ = this._refreshSubject.asObservable();

  readonly searchControl = new FormControl(null,[])

  readonly vm$ = merge(this._refresh$, routeChanged$(this._router))
  .pipe(
    switchMap(_ => combineLatest([
      this._storyService.get(),
      this._searchEnabled$.pipe(
        startWith(false)
      )
    ])),
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
    private readonly _router: Router
  ) { }

    onSearchClick() {
      this._searchEnabledSubject.next(true);
    }

    onCloseClick() {
      this._searchEnabledSubject.next(false);
    }

}
