/* tslint:disable */
import { TechnologyDto } from './technology-dto';
export interface GetTechnologiesResponse {
  errors?: Array<string>;
  technologies?: Array<TechnologyDto>;
}
