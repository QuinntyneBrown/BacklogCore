/* tslint:disable */
import { UserDto } from './user-dto';
export interface GetUsersPageResponse {
  entities?: Array<UserDto>;
  errors?: Array<string>;
  length?: number;
}
