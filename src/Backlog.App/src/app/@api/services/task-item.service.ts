/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetTaskItemByIdResponse } from '../models/get-task-item-by-id-response';
import { RemoveTaskItemResponse } from '../models/remove-task-item-response';
import { GetTaskItemsResponse } from '../models/get-task-items-response';
import { CreateTaskItemResponse } from '../models/create-task-item-response';
import { CreateTaskItemRequest } from '../models/create-task-item-request';
import { UpdateTaskItemResponse } from '../models/update-task-item-response';
import { UpdateTaskItemRequest } from '../models/update-task-item-request';
import { GetTaskItemsPageResponse } from '../models/get-task-items-page-response';
@Injectable({
  providedIn: 'root',
})
class TaskItemService extends __BaseService {
  static readonly GetTaskItemByIdPath = '/api/TaskItem/{taskItemId}';
  static readonly RemoveTaskItemPath = '/api/TaskItem/{taskItemId}';
  static readonly GetTaskItemsPath = '/api/TaskItem';
  static readonly CreateTaskItemPath = '/api/TaskItem';
  static readonly UpdateTaskItemPath = '/api/TaskItem';
  static readonly GetTaskItemsPagePath = '/api/TaskItem/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param taskItemId undefined
   * @return Success
   */
  GetTaskItemByIdResponse(taskItemId: string): __Observable<__StrictHttpResponse<GetTaskItemByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TaskItem/${encodeURIComponent(String(taskItemId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTaskItemByIdResponse>;
      })
    );
  }
  /**
   * @param taskItemId undefined
   * @return Success
   */
  GetTaskItemById(taskItemId: string): __Observable<GetTaskItemByIdResponse> {
    return this.GetTaskItemByIdResponse(taskItemId).pipe(
      __map(_r => _r.body as GetTaskItemByIdResponse)
    );
  }

  /**
   * @param taskItemId undefined
   * @return Success
   */
  RemoveTaskItemResponse(taskItemId: string): __Observable<__StrictHttpResponse<RemoveTaskItemResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/TaskItem/${encodeURIComponent(String(taskItemId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveTaskItemResponse>;
      })
    );
  }
  /**
   * @param taskItemId undefined
   * @return Success
   */
  RemoveTaskItem(taskItemId: string): __Observable<RemoveTaskItemResponse> {
    return this.RemoveTaskItemResponse(taskItemId).pipe(
      __map(_r => _r.body as RemoveTaskItemResponse)
    );
  }

  /**
   * @return Success
   */
  GetTaskItemsResponse(): __Observable<__StrictHttpResponse<GetTaskItemsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TaskItem`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTaskItemsResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetTaskItems(): __Observable<GetTaskItemsResponse> {
    return this.GetTaskItemsResponse().pipe(
      __map(_r => _r.body as GetTaskItemsResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateTaskItemResponse(body?: CreateTaskItemRequest): __Observable<__StrictHttpResponse<CreateTaskItemResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/TaskItem`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateTaskItemResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateTaskItem(body?: CreateTaskItemRequest): __Observable<CreateTaskItemResponse> {
    return this.CreateTaskItemResponse(body).pipe(
      __map(_r => _r.body as CreateTaskItemResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateTaskItemResponse(body?: UpdateTaskItemRequest): __Observable<__StrictHttpResponse<UpdateTaskItemResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/TaskItem`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateTaskItemResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateTaskItem(body?: UpdateTaskItemRequest): __Observable<UpdateTaskItemResponse> {
    return this.UpdateTaskItemResponse(body).pipe(
      __map(_r => _r.body as UpdateTaskItemResponse)
    );
  }

  /**
   * @param params The `TaskItemService.GetTaskItemsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetTaskItemsPageResponse(params: TaskItemService.GetTaskItemsPageParams): __Observable<__StrictHttpResponse<GetTaskItemsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/TaskItem/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTaskItemsPageResponse>;
      })
    );
  }
  /**
   * @param params The `TaskItemService.GetTaskItemsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetTaskItemsPage(params: TaskItemService.GetTaskItemsPageParams): __Observable<GetTaskItemsPageResponse> {
    return this.GetTaskItemsPageResponse(params).pipe(
      __map(_r => _r.body as GetTaskItemsPageResponse)
    );
  }
}

module TaskItemService {

  /**
   * Parameters for GetTaskItemsPage
   */
  export interface GetTaskItemsPageParams {
    PageSize: number;
    Index: number;
  }
}

export { TaskItemService }
