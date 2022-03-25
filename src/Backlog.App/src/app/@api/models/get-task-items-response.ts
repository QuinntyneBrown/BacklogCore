/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface GetTaskItemsResponse {
  errors?: Array<string>;
  taskItems?: Array<TaskItemDto>;
}
