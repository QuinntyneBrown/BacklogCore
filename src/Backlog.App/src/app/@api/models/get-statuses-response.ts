/* tslint:disable */
import { StatusDto } from './status-dto';
export interface GetStatusesResponse {
  errors?: Array<string>;
  statuses?: Array<StatusDto>;
}
