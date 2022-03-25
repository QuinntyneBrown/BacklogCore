/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetSprintByIdResponse } from '../models/get-sprint-by-id-response';
import { RemoveSprintResponse } from '../models/remove-sprint-response';
import { UpdateSprintResponse } from '../models/update-sprint-response';
import { UpdateSprintRequest } from '../models/update-sprint-request';
import { GetSprintsResponse } from '../models/get-sprints-response';
import { CreateSprintResponse } from '../models/create-sprint-response';
import { CreateSprintRequest } from '../models/create-sprint-request';
import { GetSprintsByStoryIdResponse } from '../models/get-sprints-by-story-id-response';
import { GetCurrentSprintResponse } from '../models/get-current-sprint-response';
import { AddSprintStoryResponse } from '../models/add-sprint-story-response';
import { AddSprintStoryRequest } from '../models/add-sprint-story-request';
import { GetSprintsPageResponse } from '../models/get-sprints-page-response';
@Injectable({
  providedIn: 'root',
})
class SprintService extends __BaseService {
  static readonly GetSprintByIdPath = '/api/Sprint/{sprintId}';
  static readonly RemoveSprintPath = '/api/Sprint/{sprintId}';
  static readonly UpdateSprintPath = '/api/Sprint';
  static readonly GetSprintsPath = '/api/Sprint';
  static readonly CreateSprintPath = '/api/Sprint';
  static readonly GetSprintsByStoryIdPath = '/api/Sprint/story/{storyId}';
  static readonly GetCurrentSprintPath = '/api/Sprint/current';
  static readonly AddSprintStoryPath = '/api/Sprint/story';
  static readonly GetSprintsPagePath = '/api/Sprint/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param SprintId undefined
   * @return Success
   */
  GetSprintByIdResponse(SprintId: string): __Observable<__StrictHttpResponse<GetSprintByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Sprint/${encodeURIComponent(String(sprintId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetSprintByIdResponse>;
      })
    );
  }
  /**
   * @param SprintId undefined
   * @return Success
   */
  GetSprintById(SprintId: string): __Observable<GetSprintByIdResponse> {
    return this.GetSprintByIdResponse(SprintId).pipe(
      __map(_r => _r.body as GetSprintByIdResponse)
    );
  }

  /**
   * @param SprintId undefined
   * @return Success
   */
  RemoveSprintResponse(SprintId: string): __Observable<__StrictHttpResponse<RemoveSprintResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Sprint/${encodeURIComponent(String(sprintId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveSprintResponse>;
      })
    );
  }
  /**
   * @param SprintId undefined
   * @return Success
   */
  RemoveSprint(SprintId: string): __Observable<RemoveSprintResponse> {
    return this.RemoveSprintResponse(SprintId).pipe(
      __map(_r => _r.body as RemoveSprintResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateSprintResponse(body?: UpdateSprintRequest): __Observable<__StrictHttpResponse<UpdateSprintResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Sprint`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateSprintResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateSprint(body?: UpdateSprintRequest): __Observable<UpdateSprintResponse> {
    return this.UpdateSprintResponse(body).pipe(
      __map(_r => _r.body as UpdateSprintResponse)
    );
  }

  /**
   * @return Success
   */
  GetSprintsResponse(): __Observable<__StrictHttpResponse<GetSprintsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Sprint`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetSprintsResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetSprints(): __Observable<GetSprintsResponse> {
    return this.GetSprintsResponse().pipe(
      __map(_r => _r.body as GetSprintsResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateSprintResponse(body?: CreateSprintRequest): __Observable<__StrictHttpResponse<CreateSprintResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Sprint`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateSprintResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateSprint(body?: CreateSprintRequest): __Observable<CreateSprintResponse> {
    return this.CreateSprintResponse(body).pipe(
      __map(_r => _r.body as CreateSprintResponse)
    );
  }

  /**
   * @param StoryId undefined
   * @return Success
   */
  GetSprintsByStoryIdResponse(StoryId: string): __Observable<__StrictHttpResponse<GetSprintsByStoryIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Sprint/story/${encodeURIComponent(String(storyId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetSprintsByStoryIdResponse>;
      })
    );
  }
  /**
   * @param StoryId undefined
   * @return Success
   */
  GetSprintsByStoryId(StoryId: string): __Observable<GetSprintsByStoryIdResponse> {
    return this.GetSprintsByStoryIdResponse(StoryId).pipe(
      __map(_r => _r.body as GetSprintsByStoryIdResponse)
    );
  }

  /**
   * @return Success
   */
  GetCurrentSprintResponse(): __Observable<__StrictHttpResponse<GetCurrentSprintResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Sprint/current`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCurrentSprintResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetCurrentSprint(): __Observable<GetCurrentSprintResponse> {
    return this.GetCurrentSprintResponse().pipe(
      __map(_r => _r.body as GetCurrentSprintResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  AddSprintStoryResponse(body?: AddSprintStoryRequest): __Observable<__StrictHttpResponse<AddSprintStoryResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Sprint/story`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddSprintStoryResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  AddSprintStory(body?: AddSprintStoryRequest): __Observable<AddSprintStoryResponse> {
    return this.AddSprintStoryResponse(body).pipe(
      __map(_r => _r.body as AddSprintStoryResponse)
    );
  }

  /**
   * @param params The `SprintService.GetSprintsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetSprintsPageResponse(params: SprintService.GetSprintsPageParams): __Observable<__StrictHttpResponse<GetSprintsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Sprint/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetSprintsPageResponse>;
      })
    );
  }
  /**
   * @param params The `SprintService.GetSprintsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetSprintsPage(params: SprintService.GetSprintsPageParams): __Observable<GetSprintsPageResponse> {
    return this.GetSprintsPageResponse(params).pipe(
      __map(_r => _r.body as GetSprintsPageResponse)
    );
  }
}

module SprintService {

  /**
   * Parameters for GetSprintsPage
   */
  export interface GetSprintsPageParams {
    PageSize: number;
    Index: number;
  }
}

export { SprintService }
