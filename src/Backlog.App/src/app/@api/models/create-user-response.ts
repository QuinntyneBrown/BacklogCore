/* tslint:disable */
import { UserDto } from './user-dto';
export interface CreateUserResponse {
  errors?: Array<string>;
  user?: UserDto;
}
