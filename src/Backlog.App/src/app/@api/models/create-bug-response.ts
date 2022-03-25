/* tslint:disable */
import { BugDto } from './bug-dto';
export interface CreateBugResponse {
  bug?: BugDto;
  errors?: Array<string>;
}
