/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { ConnectorUploadDigitalAssetResponse } from '../models/connector-upload-digital-asset-response';
@Injectable({
  providedIn: 'root',
})
class ConnectorService extends __BaseService {
  static readonly postApiConnectorPath = '/api/Connector';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Success
   */
  postApiConnectorResponse(): __Observable<__StrictHttpResponse<ConnectorUploadDigitalAssetResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Connector`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ConnectorUploadDigitalAssetResponse>;
      })
    );
  }
  /**
   * @return Success
   */
  postApiConnector(): __Observable<ConnectorUploadDigitalAssetResponse> {
    return this.postApiConnectorResponse().pipe(
      __map(_r => _r.body as ConnectorUploadDigitalAssetResponse)
    );
  }
}

module ConnectorService {
}

export { ConnectorService }
