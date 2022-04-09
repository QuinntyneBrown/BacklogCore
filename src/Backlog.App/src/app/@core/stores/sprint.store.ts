import { Injectable } from "@angular/core";
import { ServerSentEventService, SprintDto, SprintService } from "@api";
import { Observable, of } from "rxjs";
import { concatMap, exhaustMap, filter, shareReplay, startWith, switchMap, tap } from "rxjs/operators";

@Injectable({
    providedIn: "root"
})
export class SprintStore {

    constructor(
        private readonly _sprintService: SprintService,
        private readonly _serverSentEventService: ServerSentEventService
    ) { }

    get(): Observable<SprintDto[]> {
        return this._serverSentEventService.GetEvents()
    }

    current(): Observable<SprintDto> {
        // return this._serverSentEventService
        // .events$.pipe(
        //     filter(x => x.Items.Type == "UpdateSprint" || x.Items.Type == "CreateSprint"),
        //     startWith(null),            
        //     exhaustMap(_ => this._sprintService.current())
        // )

        return of(null);
    }
    
}