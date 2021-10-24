import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Story } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class StoryService implements IPagableService<Story> {

  uniqueIdentifierName: string = "storyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Story>> {
    return this._client.get<EntityPage<Story>>(`${this._baseUrl}api/story/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Story[]> {
    return this._client.get<{ stories: Story[] }>(`${this._baseUrl}api/story`)
      .pipe(
        map(x => x.stories)
      );
  }

  public getById(options: { storyId: string }): Observable<Story> {
    return this._client.get<{ story: Story }>(`${this._baseUrl}api/story/${options.storyId}`)
      .pipe(
        map(x => x.story)
      );
  }

  public remove(options: { story: Story }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/story/${options.story.storyId}`);
  }

  public create(options: { story: Story }): Observable<{ story: Story }> {
    return this._client.post<{ story: Story }>(`${this._baseUrl}api/story`, { story: options.story });
  }

  public addSkillRequirement(options: { storyId: string, competencyLevel:string, technology: string }): Observable<{ story: Story }> {
    return this._client.post<{ story: Story }>(`${this._baseUrl}api/story/skill-requirement`, options);
  }

  public update(options: { story: Story }): Observable<{ story: Story }> {
    return this._client.put<{ story: Story }>(`${this._baseUrl}api/story`, { story: options.story });
  }
}
