import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Route } from '@shared';
import { ItemRoute } from '@shared/shells/item-shell/item-route';

const routes: Routes = [
  Route.withShell([
    { path: '', redirectTo: 'stories', pathMatch: 'full' },
    { path: 'stories', loadChildren: () => import('./stories/stories.module').then(m => m.StoriesModule) },    
  ]),
  
  { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
