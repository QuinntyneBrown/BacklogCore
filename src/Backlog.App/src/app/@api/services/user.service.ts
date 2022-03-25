/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetUserByIdResponse } from '../models/get-user-by-id-response';
import { RemoveUserResponse } from '../models/remove-user-response';
import { GetUsersResponse } from '../models/get-users-response';
import { CreateUserResponse } from '../models/create-user-response';
import { CreateUserRequest } from '../models/create-user-request';
import { UpdateUserResponse } from '../models/update-user-response';
import { UpdateUserRequest } from '../models/update-user-request';
import { GetUsersPageResponse } from '../models/get-users-page-response';
import { AuthenticateResponse } from '../models/authenticate-response';
import { AuthenticateRequest } from '../models/authenticate-request';
@Injectable({
  providedIn: 'root',
})
class UserService extends __BaseService {
  static readonly GetUserByIdPath = '/api/User/{userId}';
  static readonly RemoveUserPath = '/api/User/{userId}';
  static readonly GetUsersPath = '/api/User';
  static readonly CreateUserPath = '/api/User';
  static readonly UpdateUserPath = '/api/User';
  static readonly GetUsersPagePath = '/api/User/page/{pageSize}/{index}';
  static readonly AuthenticatePath = '/api/User/token';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param UserId undefined
   * @return Success
   */
  GetUserByIdResponse(UserId: string): __Observable<__StrictHttpResponse<GetUserByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/User/${encodeURIComponent(String(userId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetUserByIdResponse>;
      })
    );
  }
  /**
   * @param UserId undefined
   * @return Success
   */
  GetUserById(UserId: string): __Observable<GetUserByIdResponse> {
    return this.GetUserByIdResponse(UserId).pipe(
      __map(_r => _r.body as GetUserByIdResponse)
    );
  }

  /**
   * @param UserId undefined
   * @return Success
   */
  RemoveUserResponse(UserId: string): __Observable<__StrictHttpResponse<RemoveUserResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/User/${encodeURIComponent(String(userId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveUserResponse>;
      })
    );
  }
  /**
   * @param UserId undefined
   * @return Success
   */
  RemoveUser(UserId: string): __Observable<RemoveUserResponse> {
    return this.RemoveUserResponse(UserId).pipe(
      __map(_r => _r.body as RemoveUserResponse)
    );
  }

  /**
   * @return Success
   */
  GetUsersResponse(): __Observable<__StrictHttpResponse<GetUsersResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/User`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetUsersResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  GetUsers(): __Observable<GetUsersResponse> {
    return this.GetUsersResponse().pipe(
      __map(_r => _r.body as GetUsersResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  CreateUserResponse(body?: CreateUserRequest): __Observable<__StrictHttpResponse<CreateUserResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/User`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateUserResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  CreateUser(body?: CreateUserRequest): __Observable<CreateUserResponse> {
    return this.CreateUserResponse(body).pipe(
      __map(_r => _r.body as CreateUserResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  UpdateUserResponse(body?: UpdateUserRequest): __Observable<__StrictHttpResponse<UpdateUserResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/User`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateUserResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  UpdateUser(body?: UpdateUserRequest): __Observable<UpdateUserResponse> {
    return this.UpdateUserResponse(body).pipe(
      __map(_r => _r.body as UpdateUserResponse)
    );
  }

  /**
   * @param params The `UserService.GetUsersPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetUsersPageResponse(params: UserService.GetUsersPageParams): __Observable<__StrictHttpResponse<GetUsersPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/User/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetUsersPageResponse>;
      })
    );
  }
  /**
   * @param params The `UserService.GetUsersPageParams` containing the following parameters:
   *
   * - `PageSize`:
   *
   * - `Index`:
   *
   * @return Success
   */
  GetUsersPage(params: UserService.GetUsersPageParams): __Observable<GetUsersPageResponse> {
    return this.GetUsersPageResponse(params).pipe(
      __map(_r => _r.body as GetUsersPageResponse)
    );
  }

  /**
   * @param body undefined
   * @return Success
   */
  AuthenticateResponse(body?: AuthenticateRequest): __Observable<__StrictHttpResponse<AuthenticateResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/User/token`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AuthenticateResponse>;
      })
    );
  }
  /**
   * @param body undefined
   * @return Success
   */
  Authenticate(body?: AuthenticateRequest): __Observable<AuthenticateResponse> {
    return this.AuthenticateResponse(body).pipe(
      __map(_r => _r.body as AuthenticateResponse)
    );
  }
}

module UserService {

  /**
   * Parameters for GetUsersPage
   */
  export interface GetUsersPageParams {
    PageSize: number;
    Index: number;
  }
}

export { UserService }
