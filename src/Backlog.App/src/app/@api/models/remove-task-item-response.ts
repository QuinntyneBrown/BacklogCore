/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface RemoveTaskItemResponse {
  errors?: Array<string>;
  taskItem?: TaskItemDto;
}
