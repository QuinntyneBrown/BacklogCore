/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface GetTaskItemByIdResponse {
  errors?: Array<string>;
  taskItem?: TaskItemDto;
}
