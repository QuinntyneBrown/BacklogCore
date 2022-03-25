/* tslint:disable */
import { BugDto } from './bug-dto';
export interface GetBugsPageResponse {
  entities?: Array<BugDto>;
  errors?: Array<string>;
  length?: number;
}
