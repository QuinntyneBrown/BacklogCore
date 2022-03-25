/* tslint:disable */
import { SprintDto } from './sprint-dto';
export interface GetSprintsPageResponse {
  entities?: Array<SprintDto>;
  errors?: Array<string>;
  length?: number;
}
