/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetStatusByIdResponse } from '../models/get-status-by-id-response';
import { RemoveStatusResponse } from '../models/remove-status-response';
import { GetStatusesResponse } from '../models/get-statuses-response';
import { CreateStatusResponse } from '../models/create-status-response';
import { CreateStatusRequest } from '../models/create-status-request';
import { UpdateStatusResponse } from '../models/update-status-response';
import { UpdateStatusRequest } from '../models/update-status-request';
import { GetStatusesPageResponse } from '../models/get-statuses-page-response';
@Injectable({
  providedIn: 'root',
})
class StatusService extends __BaseService {
  static readonly GetStatusByIdPath = '/api/Status/{statusId}';
  static readonly RemoveStatusPath = '/api/Status/{statusId}';
  static readonly GetStatusesPath = '/api/Status';
  static readonly CreateStatusPath = '/api/Status';
  static readonly UpdateStatusPath = '/api/Status';
  static readonly GetStatusesPagePath = '/api/Status/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param statusId undefined
   * @return Success
   */
  GetStatusByIdResponse(statusId: string): __Observable<__StrictHttpResponse<GetStatusByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Status/${encodeURIComponent(String(statusId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStatusByIdResponse>;
      })
    );
  }
  /**
   * @param statusId undefined
   * @return Success
   */
  GetStatusById(statusId: string): __Observable<GetStatusByIdResponse> {
    return this.GetStatusByIdResponse(statusId).pipe(
      __map(_r => _r.body as GetStatusByIdResponse)
    );
  }

  /**
   * @param statusId undefined
   * @return Success
   */
  RemoveStatusResponse(statusId: string): __Observable<__StrictHttpResponse<RemoveStatusResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Status/${encodeURIComponent(String(statusId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveStatusResponse>;
      })
    );
  }
  /**
   * @param statusId undefined
   * @return Success
   */
  RemoveStatus(statusId: string): __Observable<RemoveStatusResponse> {
    return this.RemoveStatusResponse(statusId).pipe(
      __map(_r => _r.body as RemoveStatusResponse)
    );
  }

  /**
   * @return Success
   */
  GetStatusesResponse(): __Observable<__StrictHttpResponse<GetStatusesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Status`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStatusesResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetStatuses(): __Observable<GetStatusesResponse> {
    return this.GetStatusesResponse().pipe(
      __map(_r => _r.body as GetStatusesResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateStatusResponse(body?: CreateStatusRequest): __Observable<__StrictHttpResponse<CreateStatusResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Status`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateStatusResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateStatus(body?: CreateStatusRequest): __Observable<CreateStatusResponse> {
    return this.CreateStatusResponse(body).pipe(
      __map(_r => _r.body as CreateStatusResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateStatusResponse(body?: UpdateStatusRequest): __Observable<__StrictHttpResponse<UpdateStatusResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Status`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateStatusResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateStatus(body?: UpdateStatusRequest): __Observable<UpdateStatusResponse> {
    return this.UpdateStatusResponse(body).pipe(
      __map(_r => _r.body as UpdateStatusResponse)
    );
  }

  /**
   * @param params The `StatusService.GetStatusesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetStatusesPageResponse(params: StatusService.GetStatusesPageParams): __Observable<__StrictHttpResponse<GetStatusesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Status/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetStatusesPageResponse>;
      })
    );
  }
  /**
   * @param params The `StatusService.GetStatusesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetStatusesPage(params: StatusService.GetStatusesPageParams): __Observable<GetStatusesPageResponse> {
    return this.GetStatusesPageResponse(params).pipe(
      __map(_r => _r.body as GetStatusesPageResponse)
    );
  }
}

module StatusService {

  /**
   * Parameters for GetStatusesPage
   */
  export interface GetStatusesPageParams {
    pageSize: number;
    index: number;
  }
}

export { StatusService }
