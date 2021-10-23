import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskItem } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class TaskItemService implements IPagableService<TaskItem> {

  uniqueIdentifierName: string = "taskItemId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<TaskItem>> {
    return this._client.get<EntityPage<TaskItem>>(`${this._baseUrl}api/taskItem/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<TaskItem[]> {
    return this._client.get<{ taskItems: TaskItem[] }>(`${this._baseUrl}api/taskItem`)
      .pipe(
        map(x => x.taskItems)
      );
  }

  public getById(options: { taskItemId: string }): Observable<TaskItem> {
    return this._client.get<{ taskItem: TaskItem }>(`${this._baseUrl}api/taskItem/${options.taskItemId}`)
      .pipe(
        map(x => x.taskItem)
      );
  }

  public remove(options: { taskItem: TaskItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/taskItem/${options.taskItem.taskItemId}`);
  }

  public create(options: { taskItem: TaskItem }): Observable<{ taskItem: TaskItem }> {
    return this._client.post<{ taskItem: TaskItem }>(`${this._baseUrl}api/taskItem`, { taskItem: options.taskItem });
  }
  
  public update(options: { taskItem: TaskItem }): Observable<{ taskItem: TaskItem }> {
    return this._client.put<{ taskItem: TaskItem }>(`${this._baseUrl}api/taskItem`, { taskItem: options.taskItem });
  }
}
