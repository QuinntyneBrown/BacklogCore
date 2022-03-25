/* tslint:disable */
import { TechnologyDto } from './technology-dto';
export interface CreateTechnologyResponse {
  errors?: Array<string>;
  technology?: TechnologyDto;
}
