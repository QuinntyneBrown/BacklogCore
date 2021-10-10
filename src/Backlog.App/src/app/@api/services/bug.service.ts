import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bug } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class BugService implements IPagableService<Bug> {

  uniqueIdentifierName: string = "bugId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Bug>> {
    return this._client.get<EntityPage<Bug>>(`${this._baseUrl}api/bug/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Bug[]> {
    return this._client.get<{ bugs: Bug[] }>(`${this._baseUrl}api/bug`)
      .pipe(
        map(x => x.bugs)
      );
  }

  public getById(options: { bugId: string }): Observable<Bug> {
    return this._client.get<{ bug: Bug }>(`${this._baseUrl}api/bug/${options.bugId}`)
      .pipe(
        map(x => x.bug)
      );
  }

  public remove(options: { bug: Bug }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/bug/${options.bug.bugId}`);
  }

  public create(options: { bug: Bug }): Observable<{ bug: Bug }> {
    return this._client.post<{ bug: Bug }>(`${this._baseUrl}api/bug`, { bug: options.bug });
  }
  
  public update(options: { bug: Bug }): Observable<{ bug: Bug }> {
    return this._client.put<{ bug: Bug }>(`${this._baseUrl}api/bug`, { bug: options.bug });
  }
}
