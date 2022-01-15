import { Injectable } from "@angular/core";
import { DomainEvent, Sprint, SprintService, StoredEvent } from "@api";
import { EventService } from "@api/services/event.service";
import { Observable } from "rxjs";
import { concatMap, exhaustMap, filter, shareReplay, startWith, switchMap, tap } from "rxjs/operators";

@Injectable({
    providedIn: "root"
})
export class SprintStore {

    constructor(
        private readonly _sprintService: SprintService,
        private readonly _eventService: EventService
    ) { }

    get(): Observable<Sprint[]> {
        return this._eventService
        .events$.pipe(
            filter(x => x.Items.Type == "UpdateSprint" || x.Items.Type == "CreateSprint"),
            startWith(null),
            switchMap(_ => this._sprintService.get())
        )
    }

    current(): Observable<Sprint> {
        return this._eventService
        .events$.pipe(
            filter(x => x.Items.Type == "UpdateSprint" || x.Items.Type == "CreateSprint"),
            startWith(null),            
            exhaustMap(_ => this._sprintService.current())
        )
    }
    
}