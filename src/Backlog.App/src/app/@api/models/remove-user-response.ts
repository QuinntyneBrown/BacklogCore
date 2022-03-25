/* tslint:disable */
import { UserDto } from './user-dto';
export interface RemoveUserResponse {
  errors?: Array<string>;
  user?: UserDto;
}
