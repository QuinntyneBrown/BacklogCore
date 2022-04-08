/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetProfileByIdResponse } from '../models/get-profile-by-id-response';
import { RemoveProfileResponse } from '../models/remove-profile-response';
import { GetProfilesResponse } from '../models/get-profiles-response';
import { CreateProfileResponse } from '../models/create-profile-response';
import { CreateProfileRequest } from '../models/create-profile-request';
import { UpdateProfileResponse } from '../models/update-profile-response';
import { UpdateProfileRequest } from '../models/update-profile-request';
import { GetProfilesPageResponse } from '../models/get-profiles-page-response';
@Injectable({
  providedIn: 'root',
})
class ProfileService extends __BaseService {
  static readonly GetProfileByIdPath = '/api/Profile/{profileId}';
  static readonly RemoveProfilePath = '/api/Profile/{profileId}';
  static readonly GetProfilesPath = '/api/Profile';
  static readonly CreateProfilePath = '/api/Profile';
  static readonly UpdateProfilePath = '/api/Profile';
  static readonly GetProfilesPagePath = '/api/Profile/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param profileId undefined
   * @return Success
   */
  GetProfileByIdResponse(profileId: string): __Observable<__StrictHttpResponse<GetProfileByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile/${encodeURIComponent(String(profileId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfileByIdResponse>;
      })
    );
  }
  /**
   * @param profileId undefined
   * @return Success
   */
  GetProfileById(profileId: string): __Observable<GetProfileByIdResponse> {
    return this.GetProfileByIdResponse(profileId).pipe(
      __map(_r => _r.body as GetProfileByIdResponse)
    );
  }

  /**
   * @param profileId undefined
   * @return Success
   */
  RemoveProfileResponse(profileId: string): __Observable<__StrictHttpResponse<RemoveProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Profile/${encodeURIComponent(String(profileId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveProfileResponse>;
      })
    );
  }
  /**
   * @param profileId undefined
   * @return Success
   */
  RemoveProfile(profileId: string): __Observable<RemoveProfileResponse> {
    return this.RemoveProfileResponse(profileId).pipe(
      __map(_r => _r.body as RemoveProfileResponse)
    );
  }

  /**
   * @return Success
   */
  GetProfilesResponse(): __Observable<__StrictHttpResponse<GetProfilesResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfilesResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetProfiles(): __Observable<GetProfilesResponse> {
    return this.GetProfilesResponse().pipe(
      __map(_r => _r.body as GetProfilesResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateProfileResponse(body?: CreateProfileRequest): __Observable<__StrictHttpResponse<CreateProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateProfileResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateProfile(body?: CreateProfileRequest): __Observable<CreateProfileResponse> {
    return this.CreateProfileResponse(body).pipe(
      __map(_r => _r.body as CreateProfileResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateProfileResponse(body?: UpdateProfileRequest): __Observable<__StrictHttpResponse<UpdateProfileResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Profile`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateProfileResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateProfile(body?: UpdateProfileRequest): __Observable<UpdateProfileResponse> {
    return this.UpdateProfileResponse(body).pipe(
      __map(_r => _r.body as UpdateProfileResponse)
    );
  }

  /**
   * @param params The `ProfileService.GetProfilesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetProfilesPageResponse(params: ProfileService.GetProfilesPageParams): __Observable<__StrictHttpResponse<GetProfilesPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Profile/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetProfilesPageResponse>;
      })
    );
  }
  /**
   * @param params The `ProfileService.GetProfilesPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  GetProfilesPage(params: ProfileService.GetProfilesPageParams): __Observable<GetProfilesPageResponse> {
    return this.GetProfilesPageResponse(params).pipe(
      __map(_r => _r.body as GetProfilesPageResponse)
    );
  }
}

module ProfileService {

  /**
   * Parameters for GetProfilesPage
   */
  export interface GetProfilesPageParams {
    pageSize: number;
    index: number;
  }
}

export { ProfileService }
