/* tslint:disable */
import { CompetencyLevelDto } from './competency-level-dto';
export interface GetCompetencyLevelByIdResponse {
  competencyLevel?: CompetencyLevelDto;
  errors?: Array<string>;
}
