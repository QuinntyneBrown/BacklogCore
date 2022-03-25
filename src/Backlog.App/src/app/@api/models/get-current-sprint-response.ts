/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface GetCurrentSprintResponse {
  errors?: Array<string>;
  sprint?: SprintDto;
}
