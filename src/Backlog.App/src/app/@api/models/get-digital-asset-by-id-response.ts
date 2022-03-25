/* tslint:disable */
import { DigitalAssetDto } from './digital-asset-dto';
export interface GetDigitalAssetByIdResponse {
  digitalAsset?: DigitalAssetDto;
  errors?: Array<string>;
}
