/* tslint:disable */
import { TechnologyDto } from './technology-dto';
export interface GetTechnologiesPageResponse {
  entities?: Array<TechnologyDto>;
  errors?: Array<string>;
  length?: number;
}
