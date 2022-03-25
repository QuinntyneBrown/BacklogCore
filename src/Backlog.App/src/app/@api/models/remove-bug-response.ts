/* tslint:disable */
import { BugDto } from './bug-dto';
export interface RemoveBugResponse {
  bug?: BugDto;
  errors?: Array<string>;
}
