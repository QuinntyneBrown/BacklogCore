/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface UpdateTaskItemResponse {
  errors?: Array<string>;
  taskItem?: TaskItemDto;
}
