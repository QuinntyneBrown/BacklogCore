/* tslint:disable */
import { StatusDto } from './status-dto';
export interface GetStatusesPageResponse {
  entities?: Array<StatusDto>;
  errors?: Array<string>;
  length?: number;
}
