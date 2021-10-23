import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CompentencyLevel } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class CompentencyLevelService implements IPagableService<CompentencyLevel> {

  uniqueIdentifierName: string = "compentencyLevelId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CompentencyLevel>> {
    return this._client.get<EntityPage<CompentencyLevel>>(`${this._baseUrl}api/compentencyLevel/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CompentencyLevel[]> {
    return this._client.get<{ compentencyLevels: CompentencyLevel[] }>(`${this._baseUrl}api/compentencyLevel`)
      .pipe(
        map(x => x.compentencyLevels)
      );
  }

  public getById(options: { compentencyLevelId: string }): Observable<CompentencyLevel> {
    return this._client.get<{ compentencyLevel: CompentencyLevel }>(`${this._baseUrl}api/compentencyLevel/${options.compentencyLevelId}`)
      .pipe(
        map(x => x.compentencyLevel)
      );
  }

  public remove(options: { compentencyLevel: CompentencyLevel }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/compentencyLevel/${options.compentencyLevel.compentencyLevelId}`);
  }

  public create(options: { compentencyLevel: CompentencyLevel }): Observable<{ compentencyLevel: CompentencyLevel }> {
    return this._client.post<{ compentencyLevel: CompentencyLevel }>(`${this._baseUrl}api/compentencyLevel`, { compentencyLevel: options.compentencyLevel });
  }
  
  public update(options: { compentencyLevel: CompentencyLevel }): Observable<{ compentencyLevel: CompentencyLevel }> {
    return this._client.put<{ compentencyLevel: CompentencyLevel }>(`${this._baseUrl}api/compentencyLevel`, { compentencyLevel: options.compentencyLevel });
  }
}
