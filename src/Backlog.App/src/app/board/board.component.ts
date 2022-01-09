import { Component, Input, NgModule, Pipe, PipeTransform } from '@angular/core';
import { CommonModule } from '@angular/common';
import { combineLatest, of } from 'rxjs';
import { map, shareReplay, startWith, switchMap } from 'rxjs/operators';
import { combine, storyStatus } from '@core';
import { SprintService, Story, StoryService } from '@api';

@Pipe({name: 'translateStatus', pure: true })
export class TranslateStatusPipe implements PipeTransform {
  transform(value: string): string {
    const lookUp = {
      "Assigned":"Assigned",
      "Done": "Done",
      "InProgress":"In Progress"
    }

    return lookUp[value];
  }
}

@Component({
  selector: 'bl-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss'],  
})
export class BoardComponent {

  readonly vm$ = combineLatest([
    this._sprintService.current()
  ])
  .pipe(
    switchMap(([sprint]) =>  combineLatest(        
      sprint.storyIds.map(storyId => this._storyService.getById({ storyId }))
    ).pipe(startWith([]))),
    map(stories => {
      function storyByStatus(status:string) {
        return stories.filter(story => story.status == status);
      }

      return {
        statuses: storyStatus,
        storyByStatus,
        stories
      }
    })
  );

  @Input() story: Story;

  constructor(
    private readonly _sprintService: SprintService,
    private readonly _storyService: StoryService
  ) {

  }
}

