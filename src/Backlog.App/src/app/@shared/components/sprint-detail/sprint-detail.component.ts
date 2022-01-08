import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Sprint } from '@api';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'bl-sprint-detail',
  templateUrl: './sprint-detail.component.html',
  styleUrls: ['./sprint-detail.component.scss']
})
export class SprintDetailComponent {

  readonly form: FormGroup = new FormGroup({
    sprintId: new FormControl(null, []),
    name: new FormControl(null, [Validators.required])
  });

  get sprint(): Sprint { return this.form.value as Sprint; }

  @Input("sprint") set sprint(value: Sprint) {
    if(!value?.sprintId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<Sprint> = new EventEmitter();

}

@NgModule({
  declarations: [
    SprintDetailComponent
  ],
  exports: [
    SprintDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule
  ]
})
export class SprintDetailModule { }
