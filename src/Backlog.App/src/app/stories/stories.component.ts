import { Component, OnInit } from '@angular/core';
import { StoryService } from '@api';
import { StoriesFeatureService } from '@core/feature-services/stories-feature.service';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'bl-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent  {

  public vm$ = this._storiesFeatureService.storiesUpdated$
  .pipe(
    startWith(true),
    switchMap(_ => this._storyService.get()),
    map(stories => ({ stories }))
  )

  constructor(
    private readonly _storyService: StoryService,
    private readonly _storiesFeatureService: StoriesFeatureService
  ) { }



}
