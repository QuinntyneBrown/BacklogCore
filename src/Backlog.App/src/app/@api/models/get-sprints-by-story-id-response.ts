/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface GetSprintsByStoryIdResponse {
  errors?: Array<string>;
  sprints?: Array<SprintDto>;
}
