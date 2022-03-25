/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface GetProfilesPageResponse {
  entities?: Array<ProfileDto>;
  errors?: Array<string>;
  length?: number;
}
