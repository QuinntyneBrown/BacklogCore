/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface GetDigitalAssetsPageResponse {
  entities?: Array<DigitalAssetDto>;
  errors?: Array<string>;
  length?: number;
}
