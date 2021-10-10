import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StoryStatus } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class StoryStatusService implements IPagableService<StoryStatus> {

  uniqueIdentifierName: string = "storyStatusId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<StoryStatus>> {
    return this._client.get<EntityPage<StoryStatus>>(`${this._baseUrl}api/storyStatus/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<StoryStatus[]> {
    return this._client.get<{ storyStatuses: StoryStatus[] }>(`${this._baseUrl}api/storyStatus`)
      .pipe(
        map(x => x.storyStatuses)
      );
  }

  public getById(options: { storyStatusId: string }): Observable<StoryStatus> {
    return this._client.get<{ storyStatus: StoryStatus }>(`${this._baseUrl}api/storyStatus/${options.storyStatusId}`)
      .pipe(
        map(x => x.storyStatus)
      );
  }

  public remove(options: { storyStatus: StoryStatus }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/storyStatus/${options.storyStatus.storyStatusId}`);
  }

  public create(options: { storyStatus: StoryStatus }): Observable<{ storyStatus: StoryStatus }> {
    return this._client.post<{ storyStatus: StoryStatus }>(`${this._baseUrl}api/storyStatus`, { storyStatus: options.storyStatus });
  }
  
  public update(options: { storyStatus: StoryStatus }): Observable<{ storyStatus: StoryStatus }> {
    return this._client.put<{ storyStatus: StoryStatus }>(`${this._baseUrl}api/storyStatus`, { storyStatus: options.storyStatus });
  }
}
