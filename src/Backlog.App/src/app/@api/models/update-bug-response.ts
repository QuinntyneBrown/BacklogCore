/* tslint:disable */
import { BugDto } from './bug-dto';
export interface UpdateBugResponse {
  bug?: BugDto;
  errors?: Array<string>;
}
