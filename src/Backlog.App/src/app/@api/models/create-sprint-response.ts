/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface CreateSprintResponse {
  errors?: Array<string>;
  sprint?: SprintDto;
}
