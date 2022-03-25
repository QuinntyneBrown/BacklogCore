/* tslint:disable */
import { StatusDto } from './status-dto';
export interface UpdateStatusResponse {
  errors?: Array<string>;
  status?: StatusDto;
}
