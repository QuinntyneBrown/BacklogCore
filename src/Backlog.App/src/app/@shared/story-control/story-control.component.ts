import { Component, ElementRef, EventEmitter, forwardRef, Input, OnDestroy, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormArray, FormControl, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, Validator, Validators } from '@angular/forms';
import { takeUntil, tap } from 'rxjs/operators';
import { fromEvent, Subject } from 'rxjs';
import { BaseControlValueAccessor } from '@core';

@Component({
  selector: 'bl-story-control',
  templateUrl: './story-control.component.html',
  styleUrls: ['./story-control.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => StoryControlComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => StoryControlComponent),
      multi: true
    }
  ]
})
export class StoryControlComponent extends BaseControlValueAccessor implements Validator  {

  public form = new FormGroup({
    storyId: new FormControl(null,[]),
    title: new FormControl(null, [Validators.required]),
    name: new FormControl(null, [Validators.required]),
    jiraUrl: new FormControl(null,[]),
    description: new FormControl(null, [Validators.required]),
    acceptanceCriteria: new FormControl(null, [Validators.required])
  });

  constructor(
    private readonly _elementRef: ElementRef
  ) {
    super();
  }

  @Output() public addSkillRequirementClick = new EventEmitter();

  @Output() public addDependencyRelationshipClick = new EventEmitter();

  validate(control: AbstractControl): ValidationErrors | null {
      return this.form.errors;
  }

  writeValue(obj: any): void {
    if(obj == null) {
      this.form.reset();
    }
    else {
        this.form.patchValue(obj, { emitEvent: false });
    }
  }

  registerOnChange(fn: any): void {
    this.form.valueChanges
    .pipe(takeUntil(this._destroyed$))
    .subscribe(fn);
  }

  registerOnTouched(fn: any): void {
    this._elementRef.nativeElement
      .querySelectorAll("*")
      .forEach((element: HTMLElement) => {
        fromEvent(element, "focus")
          .pipe(
            takeUntil(this._destroyed$),
            tap(x => fn())
          )
          .subscribe();
      });
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }
}
