import { Component, OnInit } from '@angular/core';
import { StoryService } from '@api';
import { Destroyable } from '@core';
import { takeUntil, tap } from 'rxjs/operators';
import { StoryActionbarService } from 'src/app/stories/story-actionbar/story-actionbar.service';

@Component({
  selector: 'bl-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss']
})
export class StoryComponent extends Destroyable  implements OnInit {
  constructor(
    private readonly _storyActionbarService: StoryActionbarService,
    private readonly _storyService: StoryService
  ) {
    super();
  }

  ngOnInit() {
    this._storyActionbarService.cancel$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => {
        alert("Cancel");
      })
    ).subscribe();

    this._storyActionbarService.save$
    .pipe(
      takeUntil(this._destroyed$),
      tap(_ => {
        alert("Save");
      })
    ).subscribe();
  }
}
