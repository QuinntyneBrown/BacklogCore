import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { StoryService } from '@api';
import { Destroyable, fullscreenDialogOptions } from '@core';
import { map, takeUntil } from 'rxjs/operators';
import { StoryDialogComponent } from '../story-dialog/story-dialog.component';

@Component({
  selector: 'bl-story-list',
  templateUrl: './story-list.component.html',
  styleUrls: ['./story-list.component.scss']
})
export class StoryListComponent extends Destroyable  {

  public vm$ =  this._storyService.get()
  .pipe(
    map(stories => {
      return {
        stories
      };
    })
  )
  constructor(
    private readonly _storyService: StoryService,
    private readonly _router: Router,
    private readonly _dialog: MatDialog
  ) {
    super();
  }


}
