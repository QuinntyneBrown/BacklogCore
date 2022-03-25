/* tslint:disable */
import { UserDto } from './user-dto';
export interface GetUsersResponse {
  errors?: Array<string>;
  users?: Array<UserDto>;
}
