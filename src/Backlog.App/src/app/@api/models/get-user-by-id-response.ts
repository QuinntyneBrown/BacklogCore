/* tslint:disable */
import { UserDto } from './user-dto';
export interface GetUserByIdResponse {
  errors?: Array<string>;
  user?: UserDto;
}
