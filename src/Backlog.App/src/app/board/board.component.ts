import { Component, Input, NgModule, Pipe, PipeTransform } from '@angular/core';
import { CommonModule } from '@angular/common';
import { combineLatest, of, Subject } from 'rxjs';
import { map, shareReplay, startWith, switchMap } from 'rxjs/operators';
import { combine, storyStatus } from '@core';
import { SprintService, Story, StoryService } from '@api';
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
    this._sprintService.current(),
    this._drop$.pipe(
      switchMap(options => this._storyService.updateStatus({
        storyId: options.storyId,
        status: options.status
        })),
      startWith(true)
    )
  ])
  .pipe(
    switchMap(([sprint]) =>  combineLatest(        
      sprint.storyIds.map(storyId => this._storyService.getById({ storyId }))
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

  @Input() story: Story;

  constructor(
    private readonly _sprintService: SprintService,
    private readonly _storyService: StoryService
  ) {

  }

  onDrop(event: CdkDragDrop<Story[]>, status: string) {

    if (event.previousContainer !== event.container) {

      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);

      const story: Story = event.container.data[event.currentIndex] as Story;

      this._dropSubject.next({
        storyId: story.storyId,
        status
      })
    }
  }
}

