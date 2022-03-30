/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetDigitalAssetsPageResponse } from '../models/get-digital-assets-page-response';
import { GetDigitalAssetByIdResponse } from '../models/get-digital-asset-by-id-response';
import { RemoveDigitalAssetResponse } from '../models/remove-digital-asset-response';
import { GetDigitalAssetsByIdsResponse } from '../models/get-digital-assets-by-ids-response';
import { UploadDigitalAssetResponse } from '../models/upload-digital-asset-response';
@Injectable({
  providedIn: 'root',
})
class DigitalAssetService extends __BaseService {
  static readonly GetDigitalAssetsPagePath = '/api/DigitalAsset/page/{pageSize}/{index}';
  static readonly GetDigitalAssetByIdPath = '/api/DigitalAsset/{digitalAssetId}';
  static readonly RemoveDigitalAssetPath = '/api/DigitalAsset/{digitalAssetId}';
  static readonly GetDigitalAssetsByIdsPath = '/api/DigitalAsset/range';
  static readonly UploadDigitalAssetPath = '/api/DigitalAsset/upload';
  static readonly getApiDigitalAssetServeDigitalAssetIdPath = '/api/DigitalAsset/serve/{digitalAssetId}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param params The `DigitalAssetService.GetDigitalAssetsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetDigitalAssetsPageResponse(params: DigitalAssetService.GetDigitalAssetsPageParams): __Observable<__StrictHttpResponse<GetDigitalAssetsPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetsPageResponse>;
      })
    );
  }
  /**
   * @param params The `DigitalAssetService.GetDigitalAssetsPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetDigitalAssetsPage(params: DigitalAssetService.GetDigitalAssetsPageParams): __Observable<GetDigitalAssetsPageResponse> {
    return this.GetDigitalAssetsPageResponse(params).pipe(
      __map(_r => _r.body as GetDigitalAssetsPageResponse)
    );
  }

  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  GetDigitalAssetByIdResponse(DigitalAssetId: string): __Observable<__StrictHttpResponse<GetDigitalAssetByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/${encodeURIComponent(String(digitalAssetId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetByIdResponse>;
      })
    );
  }
  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  GetDigitalAssetById(DigitalAssetId: string): __Observable<GetDigitalAssetByIdResponse> {
    return this.GetDigitalAssetByIdResponse(DigitalAssetId).pipe(
      __map(_r => _r.body as GetDigitalAssetByIdResponse)
    );
  }

  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  RemoveDigitalAssetResponse(DigitalAssetId: string): __Observable<__StrictHttpResponse<RemoveDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/DigitalAsset/${encodeURIComponent(String(digitalAssetId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveDigitalAssetResponse>;
      })
    );
  }
  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  RemoveDigitalAsset(DigitalAssetId: string): __Observable<RemoveDigitalAssetResponse> {
    return this.RemoveDigitalAssetResponse(DigitalAssetId).pipe(
      __map(_r => _r.body as RemoveDigitalAssetResponse)
    );
  }

  /**
   * @param DigitalAssetIds undefined
   * @return Success
   */
  GetDigitalAssetsByIdsResponse(DigitalAssetIds?: Array<string>): __Observable<__StrictHttpResponse<GetDigitalAssetsByIdsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    (DigitalAssetIds || []).forEach(val => {if (val != null) __params = __params.append('DigitalAssetIds', val.toString())});
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/range`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetDigitalAssetsByIdsResponse>;
      })
    );
  }
  /**
   * @param DigitalAssetIds undefined
   * @return Success
   */
  GetDigitalAssetsByIds(DigitalAssetIds?: Array<string>): __Observable<GetDigitalAssetsByIdsResponse> {
    return this.GetDigitalAssetsByIdsResponse(DigitalAssetIds).pipe(
      __map(_r => _r.body as GetDigitalAssetsByIdsResponse)
    );
  }

  /**
   * @return Success
   */
  UploadDigitalAssetResponse(): __Observable<__StrictHttpResponse<UploadDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/DigitalAsset/upload`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UploadDigitalAssetResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  UploadDigitalAsset(): __Observable<UploadDigitalAssetResponse> {
    return this.UploadDigitalAssetResponse().pipe(
      __map(_r => _r.body as UploadDigitalAssetResponse)
    );
  }

  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  getApiDigitalAssetServeDigitalAssetIdResponse(DigitalAssetId: string): __Observable<__StrictHttpResponse<string>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/DigitalAsset/serve/${encodeURIComponent(String(digitalAssetId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'text'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<string>;
      })
    );
  }
  /**
   * @param DigitalAssetId undefined
   * @return Success
   */
  getApiDigitalAssetServeDigitalAssetId(DigitalAssetId: string): __Observable<string> {
    return this.getApiDigitalAssetServeDigitalAssetIdResponse(DigitalAssetId).pipe(
      __map(_r => _r.body as string)
    );
  }
}

module DigitalAssetService {

  /**
   * Parameters for GetDigitalAssetsPage
   */
  export interface GetDigitalAssetsPageParams {
    PageSize: number;
    Index: number;
  }
}

export { DigitalAssetService }
