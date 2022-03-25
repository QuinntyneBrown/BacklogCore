/* tslint:disable */
import { UserDto } from './user-dto';
export interface UpdateUserResponse {
  errors?: Array<string>;
  user?: UserDto;
}
