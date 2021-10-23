import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DependencyRelationship } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class DependencyRelationshipService implements IPagableService<DependencyRelationship> {

  uniqueIdentifierName: string = "dependencyRelationshipId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<DependencyRelationship>> {
    return this._client.get<EntityPage<DependencyRelationship>>(`${this._baseUrl}api/dependencyRelationship/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<DependencyRelationship[]> {
    return this._client.get<{ dependencyRelationships: DependencyRelationship[] }>(`${this._baseUrl}api/dependencyRelationship`)
      .pipe(
        map(x => x.dependencyRelationships)
      );
  }

  public getById(options: { dependencyRelationshipId: string }): Observable<DependencyRelationship> {
    return this._client.get<{ dependencyRelationship: DependencyRelationship }>(`${this._baseUrl}api/dependencyRelationship/${options.dependencyRelationshipId}`)
      .pipe(
        map(x => x.dependencyRelationship)
      );
  }

  public remove(options: { dependencyRelationship: DependencyRelationship }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/dependencyRelationship/${options.dependencyRelationship.dependencyRelationshipId}`);
  }

  public create(options: { dependencyRelationship: DependencyRelationship }): Observable<{ dependencyRelationship: DependencyRelationship }> {
    return this._client.post<{ dependencyRelationship: DependencyRelationship }>(`${this._baseUrl}api/dependencyRelationship`, { dependencyRelationship: options.dependencyRelationship });
  }
  
  public update(options: { dependencyRelationship: DependencyRelationship }): Observable<{ dependencyRelationship: DependencyRelationship }> {
    return this._client.put<{ dependencyRelationship: DependencyRelationship }>(`${this._baseUrl}api/dependencyRelationship`, { dependencyRelationship: options.dependencyRelationship });
  }
}
