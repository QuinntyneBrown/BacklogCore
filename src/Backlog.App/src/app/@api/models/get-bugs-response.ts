/* tslint:disable */
import { BugDto } from './bug-dto';
export interface GetBugsResponse {
  bugs?: Array<BugDto>;
  errors?: Array<string>;
}
