import { Component, EventEmitter, Input, NgModule, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { UserDto } from '@api';

@Component({
  selector: 'bl-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent {

  readonly form: FormGroup = new FormGroup({
    userId: new FormControl(null, []),
    username: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required])
  });

  get user(): UserDto { return this.form.value as UserDto; }

  @Input("user") set user(value: UserDto) {
    if(!value?.userId) {
      this.form.reset({
        name: null
      })
    } else {
      this.form.patchValue(value);
    }
  }

  @Output() save: EventEmitter<UserDto> = new EventEmitter();

}

@NgModule({
  declarations: [
    UserDetailComponent
  ],
  exports: [
    UserDetailComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule
  ]
})
export class UserDetailModule { }
