/* tslint:disable */
import { TechnologyDto } from './technology-dto';
export interface GetTechnologyByIdResponse {
  errors?: Array<string>;
  technology?: TechnologyDto;
}
