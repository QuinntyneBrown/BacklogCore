/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetTechnologyByIdResponse } from '../models/get-technology-by-id-response';
import { RemoveTechnologyResponse } from '../models/remove-technology-response';
import { GetTechnologiesResponse } from '../models/get-technologies-response';
import { CreateTechnologyResponse } from '../models/create-technology-response';
import { CreateTechnologyRequest } from '../models/create-technology-request';
import { UpdateTechnologyResponse } from '../models/update-technology-response';
import { UpdateTechnologyRequest } from '../models/update-technology-request';
import { GetTechnologiesPageResponse } from '../models/get-technologies-page-response';
@Injectable({
  providedIn: 'root',
})
class TechnologyService extends __BaseService {
  static readonly GetTechnologyByIdPath = '/api/Technology/{technologyId}';
  static readonly RemoveTechnologyPath = '/api/Technology/{technologyId}';
  static readonly GetTechnologiesPath = '/api/Technology';
  static readonly CreateTechnologyPath = '/api/Technology';
  static readonly UpdateTechnologyPath = '/api/Technology';
  static readonly GetTechnologiesPagePath = '/api/Technology/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param technologyId undefined
   * @return Success
   */
  GetTechnologyByIdResponse(technologyId: string): __Observable<__StrictHttpResponse<GetTechnologyByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Technology/${encodeURIComponent(String(technologyId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTechnologyByIdResponse>;
      })
    );
  }
  /**
   * @param technologyId undefined
   * @return Success
   */
  GetTechnologyById(technologyId: string): __Observable<GetTechnologyByIdResponse> {
    return this.GetTechnologyByIdResponse(technologyId).pipe(
      __map(_r => _r.body as GetTechnologyByIdResponse)
    );
  }

  /**
   * @param technologyId undefined
   * @return Success
   */
  RemoveTechnologyResponse(technologyId: string): __Observable<__StrictHttpResponse<RemoveTechnologyResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Technology/${encodeURIComponent(String(technologyId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveTechnologyResponse>;
      })
    );
  }
  /**
   * @param technologyId undefined
   * @return Success
   */
  RemoveTechnology(technologyId: string): __Observable<RemoveTechnologyResponse> {
    return this.RemoveTechnologyResponse(technologyId).pipe(
      __map(_r => _r.body as RemoveTechnologyResponse)
    );
  }

  /**
   * @return Success
   */
  GetTechnologiesResponse(): __Observable<__StrictHttpResponse<GetTechnologiesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Technology`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTechnologiesResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetTechnologies(): __Observable<GetTechnologiesResponse> {
    return this.GetTechnologiesResponse().pipe(
      __map(_r => _r.body as GetTechnologiesResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateTechnologyResponse(body?: CreateTechnologyRequest): __Observable<__StrictHttpResponse<CreateTechnologyResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Technology`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateTechnologyResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateTechnology(body?: CreateTechnologyRequest): __Observable<CreateTechnologyResponse> {
    return this.CreateTechnologyResponse(body).pipe(
      __map(_r => _r.body as CreateTechnologyResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateTechnologyResponse(body?: UpdateTechnologyRequest): __Observable<__StrictHttpResponse<UpdateTechnologyResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Technology`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateTechnologyResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateTechnology(body?: UpdateTechnologyRequest): __Observable<UpdateTechnologyResponse> {
    return this.UpdateTechnologyResponse(body).pipe(
      __map(_r => _r.body as UpdateTechnologyResponse)
    );
  }

  /**
   * @param params The `TechnologyService.GetTechnologiesPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetTechnologiesPageResponse(params: TechnologyService.GetTechnologiesPageParams): __Observable<__StrictHttpResponse<GetTechnologiesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Technology/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetTechnologiesPageResponse>;
      })
    );
  }
  /**
   * @param params The `TechnologyService.GetTechnologiesPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetTechnologiesPage(params: TechnologyService.GetTechnologiesPageParams): __Observable<GetTechnologiesPageResponse> {
    return this.GetTechnologiesPageResponse(params).pipe(
      __map(_r => _r.body as GetTechnologiesPageResponse)
    );
  }
}

module TechnologyService {

  /**
   * Parameters for GetTechnologiesPage
   */
  export interface GetTechnologiesPageParams {
    PageSize: number;
    Index: number;
  }
}

export { TechnologyService }
