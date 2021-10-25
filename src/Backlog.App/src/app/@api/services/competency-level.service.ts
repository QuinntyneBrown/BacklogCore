import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CompetencyLevel } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class CompetencyLevelService implements IPagableService<CompetencyLevel> {

  uniqueIdentifierName: string = "competencyLevelId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CompetencyLevel>> {
    return this._client.get<EntityPage<CompetencyLevel>>(`${this._baseUrl}api/competencyLevel/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CompetencyLevel[]> {
    return this._client.get<{ competencyLevels: CompetencyLevel[] }>(`${this._baseUrl}api/competencyLevel`)
      .pipe(
        map(x => x.competencyLevels)
      );
  }

  public getById(options: { competencyLevelId: string }): Observable<CompetencyLevel> {
    return this._client.get<{ competencyLevel: CompetencyLevel }>(`${this._baseUrl}api/competencyLevel/${options.competencyLevelId}`)
      .pipe(
        map(x => x.competencyLevel)
      );
  }

  public remove(options: { competencyLevel: CompetencyLevel }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/competencyLevel/${options.competencyLevel.competencyLevelId}`);
  }

  public create(options: { competencyLevel: CompetencyLevel }): Observable<{ competencyLevel: CompetencyLevel }> {
    return this._client.post<{ competencyLevel: CompetencyLevel }>(`${this._baseUrl}api/competencyLevel`, { competencyLevel: options.competencyLevel });
  }
  
  public update(options: { competencyLevel: CompetencyLevel }): Observable<{ competencyLevel: CompetencyLevel }> {
    return this._client.put<{ competencyLevel: CompetencyLevel }>(`${this._baseUrl}api/competencyLevel`, { competencyLevel: options.competencyLevel });
  }
}
