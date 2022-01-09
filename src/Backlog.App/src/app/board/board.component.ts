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
      startWith(null)
    )
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
        stories,
        assigned: stories.filter(story => story.status == 'Assigned'),
        inProgress: stories.filter(story => story.status == 'InProgress'),
        done: stories.filter(story => story.status == 'Done')
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

