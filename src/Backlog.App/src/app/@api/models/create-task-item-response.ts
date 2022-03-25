/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface CreateTaskItemResponse {
  errors?: Array<string>;
  taskItem?: TaskItemDto;
}
