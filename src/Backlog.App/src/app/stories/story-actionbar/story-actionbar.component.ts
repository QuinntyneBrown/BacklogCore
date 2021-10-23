import { Component, OnInit } from '@angular/core';
import { StoryActionbarService } from './story-actionbar.service';

@Component({
  selector: 'bl-story-actionbar',
  templateUrl: './story-actionbar.component.html',
  styleUrls: ['./story-actionbar.component.scss']
})
export class StoryActionbarComponent {

  constructor(
    private readonly _storyActionbarService: StoryActionbarService
  ) { }

  public cancel() {
    this._storyActionbarService.cancel$.next();
  }

  public save() {
    this._storyActionbarService.save$.next();
  }

}
