/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { SearchStoriesResponse } from '../models/search-stories-response';
import { GetStoryByIdResponse } from '../models/get-story-by-id-response';
import { RemoveStoryResponse } from '../models/remove-story-response';
import { GetStoriesResponse } from '../models/get-stories-response';
import { CreateStoryResponse } from '../models/create-story-response';
import { CreateStoryRequest } from '../models/create-story-request';
import { UpdateStoryDescriptionResponse } from '../models/update-story-description-response';
import { UpdateStoryRequest } from '../models/update-story-request';
import { AddStorySkillRequirementResponse } from '../models/add-story-skill-requirement-response';
import { AddStorySkillRequirementRequest } from '../models/add-story-skill-requirement-request';
import { UpdateStoryDependsOnResponse } from '../models/update-story-depends-on-response';
import { UpdateStoryDependsOnRequest } from '../models/update-story-depends-on-request';
import { UpdateStoryStatusResponse } from '../models/update-story-status-response';
import { UpdateStoryStatusRequest } from '../models/update-story-status-request';
import { GetStoriesPageResponse } from '../models/get-stories-page-response';
import { UpdateStoryJiraUrlResponse } from '../models/update-story-jira-url-response';
import { UpdateStoryJiraUrlRequest } from '../models/update-story-jira-url-request';
@Injectable({
  providedIn: 'root',
})
class StoryService extends __BaseService {
  static readonly SearchStoriesPath = '/api/Story/search/{query}';
  static readonly GetStoryByIdPath = '/api/Story/{storyId}';
  static readonly RemoveStoryPath = '/api/Story/{storyId}';
  static readonly GetStoriesPath = '/api/Story';
  static readonly CreateStoryPath = '/api/Story';
  static readonly UpdateStoryPath = '/api/Story';
  static readonly AddStorySkillRequirementPath = '/api/Story/skill-requirement';
  static readonly UpdateStoryDependsOnPath = '/api/Story/depends-on';
  static readonly UpdateStoryStatusPath = '/api/Story/status';
  static readonly GetStoriesPagePath = '/api/Story/page/{pageSize}/{index}';
  static readonly UpdateStoryJiraUrlPath = '/api/Story/jira';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param query undefined
   * @return Success
   */
  SearchStoriesResponse(query: string): __Observable<__StrictHttpResponse<SearchStoriesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Story/search/${encodeURIComponent(String(query))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<SearchStoriesResponse>;
      })
    );
  }
  /**
   * @param query undefined
   * @return Success
   */
  SearchStories(query: string): __Observable<SearchStoriesResponse> {
    return this.SearchStoriesResponse(query).pipe(
      __map(_r => _r.body as SearchStoriesResponse)
    );
  }

  /**
   * @param storyId undefined
   * @return Success
   */
  GetStoryByIdResponse(storyId: string): __Observable<__StrictHttpResponse<GetStoryByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Story/${encodeURIComponent(String(storyId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStoryByIdResponse>;
      })
    );
  }
  /**
   * @param storyId undefined
   * @return Success
   */
  GetStoryById(storyId: string): __Observable<GetStoryByIdResponse> {
    return this.GetStoryByIdResponse(storyId).pipe(
      __map(_r => _r.body as GetStoryByIdResponse)
    );
  }

  /**
   * @param storyId undefined
   * @return Success
   */
  RemoveStoryResponse(storyId: string): __Observable<__StrictHttpResponse<RemoveStoryResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Story/${encodeURIComponent(String(storyId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveStoryResponse>;
      })
    );
  }
  /**
   * @param storyId undefined
   * @return Success
   */
  RemoveStory(storyId: string): __Observable<RemoveStoryResponse> {
    return this.RemoveStoryResponse(storyId).pipe(
      __map(_r => _r.body as RemoveStoryResponse)
    );
  }

  /**
   * @return Success
   */
  GetStoriesResponse(): __Observable<__StrictHttpResponse<GetStoriesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Story`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStoriesResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetStories(): __Observable<GetStoriesResponse> {
    return this.GetStoriesResponse().pipe(
      __map(_r => _r.body as GetStoriesResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateStoryResponse(body?: CreateStoryRequest): __Observable<__StrictHttpResponse<CreateStoryResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Story`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateStoryResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateStory(body?: CreateStoryRequest): __Observable<CreateStoryResponse> {
    return this.CreateStoryResponse(body).pipe(
      __map(_r => _r.body as CreateStoryResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryResponse(body?: UpdateStoryRequest): __Observable<__StrictHttpResponse<UpdateStoryDescriptionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Story`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateStoryDescriptionResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateStory(body?: UpdateStoryRequest): __Observable<UpdateStoryDescriptionResponse> {
    return this.UpdateStoryResponse(body).pipe(
      __map(_r => _r.body as UpdateStoryDescriptionResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  AddStorySkillRequirementResponse(body?: AddStorySkillRequirementRequest): __Observable<__StrictHttpResponse<AddStorySkillRequirementResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Story/skill-requirement`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddStorySkillRequirementResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  AddStorySkillRequirement(body?: AddStorySkillRequirementRequest): __Observable<AddStorySkillRequirementResponse> {
    return this.AddStorySkillRequirementResponse(body).pipe(
      __map(_r => _r.body as AddStorySkillRequirementResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryDependsOnResponse(body?: UpdateStoryDependsOnRequest): __Observable<__StrictHttpResponse<UpdateStoryDependsOnResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Story/depends-on`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateStoryDependsOnResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryDependsOn(body?: UpdateStoryDependsOnRequest): __Observable<UpdateStoryDependsOnResponse> {
    return this.UpdateStoryDependsOnResponse(body).pipe(
      __map(_r => _r.body as UpdateStoryDependsOnResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryStatusResponse(body?: UpdateStoryStatusRequest): __Observable<__StrictHttpResponse<UpdateStoryStatusResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Story/status`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateStoryStatusResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryStatus(body?: UpdateStoryStatusRequest): __Observable<UpdateStoryStatusResponse> {
    return this.UpdateStoryStatusResponse(body).pipe(
      __map(_r => _r.body as UpdateStoryStatusResponse)
    );
  }

  /**
   * @param params The `StoryService.GetStoriesPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetStoriesPageResponse(params: StoryService.GetStoriesPageParams): __Observable<__StrictHttpResponse<GetStoriesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Story/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStoriesPageResponse>;
      })
    );
  }
  /**
   * @param params The `StoryService.GetStoriesPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetStoriesPage(params: StoryService.GetStoriesPageParams): __Observable<GetStoriesPageResponse> {
    return this.GetStoriesPageResponse(params).pipe(
      __map(_r => _r.body as GetStoriesPageResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryJiraUrlResponse(body?: UpdateStoryJiraUrlRequest): __Observable<__StrictHttpResponse<UpdateStoryJiraUrlResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Story/jira`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateStoryJiraUrlResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateStoryJiraUrl(body?: UpdateStoryJiraUrlRequest): __Observable<UpdateStoryJiraUrlResponse> {
    return this.UpdateStoryJiraUrlResponse(body).pipe(
      __map(_r => _r.body as UpdateStoryJiraUrlResponse)
    );
  }
}

module StoryService {

  /**
   * Parameters for GetStoriesPage
   */
  export interface GetStoriesPageParams {
    PageSize: number;
    Index: number;
  }
}

export { StoryService }
