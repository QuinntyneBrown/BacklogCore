/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface GetSprintByIdResponse {
  errors?: Array<string>;
  sprint?: SprintDto;
}
