import { Component, EventEmitter, forwardRef, Output } from '@angular/core';
import { FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { BaseControl } from '@core';
import { StoryService } from '@api';

@Component({
  selector: 'bl-search-stories-control',
  templateUrl: './search-stories-control.component.html',
  styleUrls: ['./search-stories-control.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SearchStoriesControlComponent),
      multi: true
    }
  ]
})
export class SearchStoriesControlComponent extends BaseControl  {

  public formControl: FormControl = new FormControl(null,[]);

  @Output() public closeClick: EventEmitter<any> = new EventEmitter();

  constructor(
    private readonly _storyService: StoryService
  ) {
    super();
  }

  writeValue(obj: any): void {

  }

  registerOnChange(fn: any): void {
    this.formControl.valueChanges
    .pipe(
      takeUntil(this._destroyed$),
      )
    .subscribe(fn);
  }
}
