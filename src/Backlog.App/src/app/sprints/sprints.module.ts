import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SprintDetailModule, SprintListModule, ListDetailModule } from '@shared';
import { SprintsRoutingModule } from './sprints-routing.module';
import { SprintsComponent } from './sprints.component';



@NgModule({
  declarations: [
    SprintsComponent
  ],
  imports: [
    CommonModule,
    SprintsRoutingModule,
    SprintListModule,
    SprintDetailModule,
    ListDetailModule
  ]
})
export class SprintsModule { }
