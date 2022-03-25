/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface GetSprintsResponse {
  errors?: Array<string>;
  sprints?: Array<SprintDto>;
}
