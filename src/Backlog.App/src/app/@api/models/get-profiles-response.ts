/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface GetProfilesResponse {
  errors?: Array<string>;
  profiles?: Array<ProfileDto>;
}
