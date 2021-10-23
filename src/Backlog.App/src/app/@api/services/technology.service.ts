import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Technology } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class TechnologyService implements IPagableService<Technology> {

  uniqueIdentifierName: string = "technologyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Technology>> {
    return this._client.get<EntityPage<Technology>>(`${this._baseUrl}api/technology/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Technology[]> {
    return this._client.get<{ technologies: Technology[] }>(`${this._baseUrl}api/technology`)
      .pipe(
        map(x => x.technologies)
      );
  }

  public getById(options: { technologyId: string }): Observable<Technology> {
    return this._client.get<{ technology: Technology }>(`${this._baseUrl}api/technology/${options.technologyId}`)
      .pipe(
        map(x => x.technology)
      );
  }

  public remove(options: { technology: Technology }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/technology/${options.technology.technologyId}`);
  }

  public create(options: { technology: Technology }): Observable<{ technology: Technology }> {
    return this._client.post<{ technology: Technology }>(`${this._baseUrl}api/technology`, { technology: options.technology });
  }
  
  public update(options: { technology: Technology }): Observable<{ technology: Technology }> {
    return this._client.put<{ technology: Technology }>(`${this._baseUrl}api/technology`, { technology: options.technology });
  }
}
