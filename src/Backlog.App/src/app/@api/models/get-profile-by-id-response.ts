/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface GetProfileByIdResponse {
  errors?: Array<string>;
  profile?: ProfileDto;
}
