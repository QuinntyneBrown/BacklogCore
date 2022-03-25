/* tslint:disable */
import { CompetencyLevelDto } from './competency-level-dto';
export interface GetCompetencyLevelsResponse {
  competencyLevels?: Array<CompetencyLevelDto>;
  errors?: Array<string>;
}
