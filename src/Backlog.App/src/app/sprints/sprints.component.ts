import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SprintService, SprintDto } from '@api';
import { combine } from '@core';
import { BehaviorSubject, from, Observable, of, Subject } from 'rxjs';
import { map, pluck, switchMap, tap } from 'rxjs/operators';


@Component({
  selector: 'bl-sprints',
  templateUrl: './sprints.component.html',
  styleUrls: ['./sprints.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SprintsComponent {

  private readonly _saveSubject: Subject<SprintDto> = new Subject();
  private readonly _selectSubject: Subject<SprintDto> = new Subject();
  private readonly _createSubject: Subject<void> = new Subject();
  private readonly _deleteSubject: Subject<SprintDto> = new Subject();
  private readonly _refreshSubject: BehaviorSubject<null> = new BehaviorSubject(null);

  readonly vm$ = this._refreshSubject
  .pipe(
    switchMap(_ => combine([
      this._sprintService.GetSprints().pipe(pluck("sprints")),
      this._selected$,
      this._createSubject.pipe(switchMap(_ => this._handleCreate())),
      this._saveSubject.pipe(switchMap(sprint => this._handleSave(sprint))),
      this._selectSubject.pipe(switchMap(sprint => this._handleSelect(sprint))),
      this._deleteSubject.pipe(switchMap(sprint => this._handleDelete(sprint)))
    ])),
    map(([sprints, selected]) => ({ sprints, selected }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _sprintService: SprintService,
    private readonly _router: Router,  
  ) { }

  private _handleSelect(sprint: SprintDto): Observable<boolean> {
    return from(this._router.navigate(["/","sprints","edit", sprint.sprintId]));
  }

  private _handleCreate(): Observable<boolean> {
    return from(this._router.navigate(["/","sprints","create"]));
  }

  private _handleSave(sprint: SprintDto): Observable<boolean> {
    return (sprint.sprintId ? this._sprintService.UpdateSprint({ sprint }) : this._sprintService.CreateSprint({ sprint }))
    .pipe(     
      switchMap(_ => this._router.navigate(["/","sprints"])),
      tap(_ => this._refreshSubject.next(null))
      );    
  }

  private _handleDelete(sprint: SprintDto): Observable<boolean> {
    return this._sprintService.RemoveSprint(sprint.sprintId)
    .pipe(
      switchMap(_ => this._router.navigate(["/","sprints"])),
      tap(_ => this._refreshSubject.next(null))
    );
  }

  private _selected$: Observable<SprintDto> = this._activatedRoute
  .paramMap
  .pipe(
    map(x => x.get("sprintId")),
    switchMap((sprintId: string) => sprintId ? this._sprintService.GetSprintById(sprintId).pipe(pluck("sprint")) : of({} as Sprint)));

  onSave(sprint: SprintDto) {
    this._saveSubject.next(sprint);
  }

  onSelect(sprint: SprintDto) {
    this._selectSubject.next(sprint);
  }

  onCreate() {
    this._createSubject.next();
  }

  onDelete(sprint: SprintDto) {
    this._deleteSubject.next(sprint);
  }
}
