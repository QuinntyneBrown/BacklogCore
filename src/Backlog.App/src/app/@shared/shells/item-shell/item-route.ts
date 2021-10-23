import { Route as NgRoute, Routes } from '@angular/router';
import { ItemShellComponent } from './item-shell.component';


export class ItemRoute {
  static withShell(routes: Routes): NgRoute {
    return {
      path: '',
      component: ItemShellComponent,
      children: routes
    };
  }
};
