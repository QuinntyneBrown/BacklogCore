/* tslint:disable */
import { StatusDto } from './status-dto';
export interface GetStatusByIdResponse {
  errors?: Array<string>;
  status?: StatusDto;
}
