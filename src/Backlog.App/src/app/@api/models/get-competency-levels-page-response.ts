/* tslint:disable */
import { CompetencyLevelDto } from './competency-level-dto';
export interface GetCompetencyLevelsPageResponse {
  entities?: Array<CompetencyLevelDto>;
  errors?: Array<string>;
  length?: number;
}
