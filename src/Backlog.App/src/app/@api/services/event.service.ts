import { Inject, Injectable } from "@angular/core";
import { BASE_URL } from "@core";
import { fromEvent } from "rxjs";
import { map } from "rxjs/operators";

@Injectable({
    providedIn: "root"
})
export class EventService {

    readonly events$ = fromEvent(new EventSource(`${this._baseUrl}api/events`), "message")
    .pipe(
        map((messsagEvent: MessageEvent<any>) => JSON.parse(messsagEvent.data)),
    );

    constructor(
        @Inject(BASE_URL) private readonly _baseUrl: string
    ) { }
}