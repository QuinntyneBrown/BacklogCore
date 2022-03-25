/* tslint:disable */
import { StatusDto } from './status-dto';
export interface CreateStatusResponse {
  errors?: Array<string>;
  status?: StatusDto;
}
