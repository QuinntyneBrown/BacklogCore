import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Sprint } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BASE_URL } from '@core';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  addStory(options: { storyId: string, sprintId: string}) {
    return this._client.post<{ sprint: Sprint }>(`${this._baseUrl}api/sprint/story`, { sprintId: options.sprintId, storyId: options.storyId });
  }

  public get(): Observable<Sprint[]> {
    return this._client.get<{ sprints: Sprint[] }>(`${this._baseUrl}api/sprint`)
      .pipe(
        map(x => x.sprints)
      );
  }

  public current(): Observable<Sprint> {
    return this._client.get<{ sprint: Sprint }>(`${this._baseUrl}api/sprint/current`)
      .pipe(
        map(x => x.sprint)
      );
  }

  public getById(options: { sprintId: string }): Observable<Sprint> {
    return this._client.get<{ sprint: Sprint }>(`${this._baseUrl}api/sprint/${options.sprintId}`)
      .pipe(
        map(x => x.sprint)
      );
  }

  public getByStoryId(options: { storyId: string }): Observable<Sprint[]> {
    return this._client.get<{ sprints: Sprint[] }>(`${this._baseUrl}api/sprint/story/${options.storyId}`)
      .pipe(
        map(x => x.sprints)
      );
  }

  public remove(options: { sprint: Sprint }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/sprint/${options.sprint.sprintId}`);
  }

  public create(options: { sprint: Sprint }): Observable<{ sprint: Sprint }> {
    return this._client.post<{ sprint: Sprint }>(`${this._baseUrl}api/sprint`, { sprint: options.sprint });
  }
  
  public update(options: { sprint: Sprint }): Observable<{ sprint: Sprint }> {
    return this._client.put<{ sprint: Sprint }>(`${this._baseUrl}api/sprint`, { sprint: options.sprint });
  }
}
