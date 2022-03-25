/* tslint:disable */
import { BugDto } from './bug-dto';
export interface GetBugByIdResponse {
  bug?: BugDto;
  errors?: Array<string>;
}
