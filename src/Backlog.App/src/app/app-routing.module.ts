import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Route } from '@shared';


const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: 'stories', pathMatch: 'full' },
    { path: 'stories', loadChildren: () => import('./stories/stories.module').then(m => m.StoriesModule) },    
    { path: 'sprints', loadChildren: () => import('./sprints/sprints.module').then(m => m.SprintsModule) },
    { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
    { path: 'board', loadChildren: () => import('./board/board.module').then(m => m.BoardModule) }
  ]),
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
