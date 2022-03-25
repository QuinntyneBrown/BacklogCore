/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface CreateProfileResponse {
  errors?: Array<string>;
  profile?: ProfileDto;
}
