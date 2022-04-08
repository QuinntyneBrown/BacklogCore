/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetBugByIdResponse } from '../models/get-bug-by-id-response';
import { RemoveBugResponse } from '../models/remove-bug-response';
import { GetBugsResponse } from '../models/get-bugs-response';
import { CreateBugResponse } from '../models/create-bug-response';
import { CreateBugRequest } from '../models/create-bug-request';
import { UpdateBugResponse } from '../models/update-bug-response';
import { UpdateBugRequest } from '../models/update-bug-request';
import { GetBugsPageResponse } from '../models/get-bugs-page-response';
@Injectable({
  providedIn: 'root',
})
class BugService extends __BaseService {
  static readonly GetBugByIdPath = '/api/Bug/{bugId}';
  static readonly RemoveBugPath = '/api/Bug/{bugId}';
  static readonly GetBugsPath = '/api/Bug';
  static readonly CreateBugPath = '/api/Bug';
  static readonly UpdateBugPath = '/api/Bug';
  static readonly GetBugsPagePath = '/api/Bug/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param bugId undefined
   * @return Success
   */
  GetBugByIdResponse(bugId: string): __Observable<__StrictHttpResponse<GetBugByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Bug/${encodeURIComponent(String(bugId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetBugByIdResponse>;
      })
    );
  }
  /**
   * @param bugId undefined
   * @return Success
   */
  GetBugById(bugId: string): __Observable<GetBugByIdResponse> {
    return this.GetBugByIdResponse(bugId).pipe(
      __map(_r => _r.body as GetBugByIdResponse)
    );
  }

  /**
   * @param bugId undefined
   * @return Success
   */
  RemoveBugResponse(bugId: string): __Observable<__StrictHttpResponse<RemoveBugResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Bug/${encodeURIComponent(String(bugId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveBugResponse>;
      })
    );
  }
  /**
   * @param bugId undefined
   * @return Success
   */
  RemoveBug(bugId: string): __Observable<RemoveBugResponse> {
    return this.RemoveBugResponse(bugId).pipe(
      __map(_r => _r.body as RemoveBugResponse)
    );
  }

  /**
   * @return Success
   */
  GetBugsResponse(): __Observable<__StrictHttpResponse<GetBugsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Bug`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetBugsResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetBugs(): __Observable<GetBugsResponse> {
    return this.GetBugsResponse().pipe(
      __map(_r => _r.body as GetBugsResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateBugResponse(body?: CreateBugRequest): __Observable<__StrictHttpResponse<CreateBugResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Bug`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateBugResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateBug(body?: CreateBugRequest): __Observable<CreateBugResponse> {
    return this.CreateBugResponse(body).pipe(
      __map(_r => _r.body as CreateBugResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateBugResponse(body?: UpdateBugRequest): __Observable<__StrictHttpResponse<UpdateBugResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Bug`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateBugResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateBug(body?: UpdateBugRequest): __Observable<UpdateBugResponse> {
    return this.UpdateBugResponse(body).pipe(
      __map(_r => _r.body as UpdateBugResponse)
    );
  }

  /**
   * @param params The `BugService.GetBugsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetBugsPageResponse(params: BugService.GetBugsPageParams): __Observable<__StrictHttpResponse<GetBugsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Bug/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetBugsPageResponse>;
      })
    );
  }
  /**
   * @param params The `BugService.GetBugsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetBugsPage(params: BugService.GetBugsPageParams): __Observable<GetBugsPageResponse> {
    return this.GetBugsPageResponse(params).pipe(
      __map(_r => _r.body as GetBugsPageResponse)
    );
  }
}

module BugService {

  /**
   * Parameters for GetBugsPage
   */
  export interface GetBugsPageParams {
    pageSize: number;
    index: number;
  }
}

export { BugService }
