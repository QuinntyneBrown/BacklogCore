/* tslint:disable */
import { ProfileDto } from './profile-dto';
export interface UpdateProfileResponse {
  errors?: Array<string>;
  profile?: ProfileDto;
}
