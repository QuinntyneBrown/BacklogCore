import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { SprintDto } from '@api';

@Component({
  selector: 'bl-sprint-detail',
  templateUrl: './sprint-detail.component.html',
  styleUrls: ['./sprint-detail.component.scss']
})
export class SprintDetailComponent {

  readonly form: FormGroup = new FormGroup({
    sprintId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required]),
    start: new FormControl(null, [Validators.required]),
    end: new FormControl(null, [Validators.required])
  });

  get sprint(): SprintDto { return this.form.value as SprintDto; }

  @Input("sprint") set sprint(value: SprintDto) {
    if(!value?.sprintId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<SprintDto> = new EventEmitter();

}

@NgModule({
  declarations: [
    SprintDetailComponent
  ],
  exports: [
    SprintDetailComponent
  ],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS }
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule
  ]
})
export class SprintDetailModule { }
