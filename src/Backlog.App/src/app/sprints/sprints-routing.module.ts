import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SprintsComponent } from './sprints.component';

const routes: Routes = [
  { path: '', component: SprintsComponent },
  { path: 'create', component: SprintsComponent },
  { path: 'edit/:sprintId', component: SprintsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SprintsRoutingModule { }
