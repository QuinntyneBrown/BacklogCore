/* tslint:disable */
import { TaskItemDto } from './task-item-dto';
export interface GetTaskItemsPageResponse {
  entities?: Array<TaskItemDto>;
  errors?: Array<string>;
  length?: number;
}
