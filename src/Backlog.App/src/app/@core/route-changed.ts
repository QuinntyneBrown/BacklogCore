import { NavigationEnd, Router } from "@angular/router";
import { filter } from "rxjs/operators";

export function routeChanged$(router: Router) {
    return router.events
    .pipe(
        filter(e => e instanceof NavigationEnd)
    )
}