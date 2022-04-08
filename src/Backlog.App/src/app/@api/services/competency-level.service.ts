/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetCompetencyLevelByIdResponse } from '../models/get-competency-level-by-id-response';
import { RemoveCompetencyLevelResponse } from '../models/remove-competency-level-response';
import { GetCompetencyLevelsResponse } from '../models/get-competency-levels-response';
import { CreateCompetencyLevelResponse } from '../models/create-competency-level-response';
import { CreateCompetencyLevelRequest } from '../models/create-competency-level-request';
import { UpdateCompetencyLevelResponse } from '../models/update-competency-level-response';
import { UpdateCompetencyLevelRequest } from '../models/update-competency-level-request';
import { GetCompetencyLevelsPageResponse } from '../models/get-competency-levels-page-response';
@Injectable({
  providedIn: 'root',
})
class CompetencyLevelService extends __BaseService {
  static readonly GetCompetencyLevelByIdPath = '/api/CompetencyLevel/{competencyLevelId}';
  static readonly RemoveCompetencyLevelPath = '/api/CompetencyLevel/{competencyLevelId}';
  static readonly GetCompetencyLevelsPath = '/api/CompetencyLevel';
  static readonly CreateCompetencyLevelPath = '/api/CompetencyLevel';
  static readonly UpdateCompetencyLevelPath = '/api/CompetencyLevel';
  static readonly GetCompetencyLevelsPagePath = '/api/CompetencyLevel/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param competencyLevelId undefined
   * @return Success
   */
  GetCompetencyLevelByIdResponse(competencyLevelId: string): __Observable<__StrictHttpResponse<GetCompetencyLevelByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CompetencyLevel/${encodeURIComponent(String(competencyLevelId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCompetencyLevelByIdResponse>;
      })
    );
  }
  /**
   * @param competencyLevelId undefined
   * @return Success
   */
  GetCompetencyLevelById(competencyLevelId: string): __Observable<GetCompetencyLevelByIdResponse> {
    return this.GetCompetencyLevelByIdResponse(competencyLevelId).pipe(
      __map(_r => _r.body as GetCompetencyLevelByIdResponse)
    );
  }

  /**
   * @param competencyLevelId undefined
   * @return Success
   */
  RemoveCompetencyLevelResponse(competencyLevelId: string): __Observable<__StrictHttpResponse<RemoveCompetencyLevelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/CompetencyLevel/${encodeURIComponent(String(competencyLevelId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveCompetencyLevelResponse>;
      })
    );
  }
  /**
   * @param competencyLevelId undefined
   * @return Success
   */
  RemoveCompetencyLevel(competencyLevelId: string): __Observable<RemoveCompetencyLevelResponse> {
    return this.RemoveCompetencyLevelResponse(competencyLevelId).pipe(
      __map(_r => _r.body as RemoveCompetencyLevelResponse)
    );
  }

  /**
   * @return Success
   */
  GetCompetencyLevelsResponse(): __Observable<__StrictHttpResponse<GetCompetencyLevelsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CompetencyLevel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCompetencyLevelsResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetCompetencyLevels(): __Observable<GetCompetencyLevelsResponse> {
    return this.GetCompetencyLevelsResponse().pipe(
      __map(_r => _r.body as GetCompetencyLevelsResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateCompetencyLevelResponse(body?: CreateCompetencyLevelRequest): __Observable<__StrictHttpResponse<CreateCompetencyLevelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/CompetencyLevel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateCompetencyLevelResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateCompetencyLevel(body?: CreateCompetencyLevelRequest): __Observable<CreateCompetencyLevelResponse> {
    return this.CreateCompetencyLevelResponse(body).pipe(
      __map(_r => _r.body as CreateCompetencyLevelResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateCompetencyLevelResponse(body?: UpdateCompetencyLevelRequest): __Observable<__StrictHttpResponse<UpdateCompetencyLevelResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/CompetencyLevel`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateCompetencyLevelResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateCompetencyLevel(body?: UpdateCompetencyLevelRequest): __Observable<UpdateCompetencyLevelResponse> {
    return this.UpdateCompetencyLevelResponse(body).pipe(
      __map(_r => _r.body as UpdateCompetencyLevelResponse)
    );
  }

  /**
   * @param params The `CompetencyLevelService.GetCompetencyLevelsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetCompetencyLevelsPageResponse(params: CompetencyLevelService.GetCompetencyLevelsPageParams): __Observable<__StrictHttpResponse<GetCompetencyLevelsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CompetencyLevel/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCompetencyLevelsPageResponse>;
      })
    );
  }
  /**
   * @param params The `CompetencyLevelService.GetCompetencyLevelsPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetCompetencyLevelsPage(params: CompetencyLevelService.GetCompetencyLevelsPageParams): __Observable<GetCompetencyLevelsPageResponse> {
    return this.GetCompetencyLevelsPageResponse(params).pipe(
      __map(_r => _r.body as GetCompetencyLevelsPageResponse)
    );
  }
}

module CompetencyLevelService {

  /**
   * Parameters for GetCompetencyLevelsPage
   */
  export interface GetCompetencyLevelsPageParams {
    pageSize: number;
    index: number;
  }
}

export { CompetencyLevelService }
