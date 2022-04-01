import { Component, Input, Pipe, PipeTransform } from '@angular/core';
import { combineLatest, Subject } from 'rxjs';
import { map, pluck, startWith, switchMap } from 'rxjs/operators';
import { storyStatus } from '@core';
import { SprintService, StoryDto, StoryService } from '@api';
import { CdkDragDrop, transferArrayItem } from '@angular/cdk/drag-drop';

@Pipe({name: 'translateStatus', pure: true })
export class TranslateStatusPipe implements PipeTransform {
  transform(value: string): string {
    const lookUp = {
      "New":"New",
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

  private readonly _dropSubject: Subject<{ storyId: string, status: string }> = new Subject();

  private readonly _drop$ = this._dropSubject.asObservable();

  readonly vm$ = combineLatest([
    this._sprintService.GetCurrentSprint().pipe(pluck("sprint")),
    this._drop$.pipe(
      switchMap(options => this._storyService.UpdateStoryStatus({
        storyId: options.storyId,
        status: options.status
        })),
      startWith(true)
    )
  ])
  .pipe(
    switchMap(([sprint]) =>  combineLatest(        
      sprint.storyIds.map(storyId => this._storyService.GetStoryById(storyId).pipe(pluck("story")))
    ).pipe(startWith([]))),
    map(stories => {

      stories = stories.filter(x => storyStatus.indexOf(x.status) > -1);

      const storiesGroupedByStatus = storyStatus.reduce((accumulatedValue,status) => {  
        accumulatedValue[status] = stories.filter(story => story.status == status);
        return accumulatedValue;
      },{ });

      return {
        statuses: storyStatus,
        stories,
        storiesGroupedByStatus
      }
    })
  );

  @Input() story: StoryDto;

  constructor(
    private readonly _sprintService: SprintService,
    private readonly _storyService: StoryService
  ) { }

  onDrop(event: CdkDragDrop<StoryDto[]>, status: string) {

    if (event.previousContainer !== event.container) {

      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);

      const story: StoryDto = event.container.data[event.currentIndex] as StoryDto;

      this._dropSubject.next({
        storyId: story.storyId,
        status
      })
    }
  }
}

