import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Status } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class StatusService implements IPagableService<Status> {

  uniqueIdentifierName: string = "statusId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Status>> {
    return this._client.get<EntityPage<Status>>(`${this._baseUrl}api/status/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Status[]> {
    return this._client.get<{ statuses: Status[] }>(`${this._baseUrl}api/status`)
      .pipe(
        map(x => x.statuses)
      );
  }

  public getById(options: { statusId: string }): Observable<Status> {
    return this._client.get<{ status: Status }>(`${this._baseUrl}api/status/${options.statusId}`)
      .pipe(
        map(x => x.status)
      );
  }

  public remove(options: { status: Status }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/status/${options.status.statusId}`);
  }

  public create(options: { status: Status }): Observable<{ status: Status }> {
    return this._client.post<{ status: Status }>(`${this._baseUrl}api/status`, { status: options.status });
  }
  
  public update(options: { status: Status }): Observable<{ status: Status }> {
    return this._client.put<{ status: Status }>(`${this._baseUrl}api/status`, { status: options.status });
  }
}
